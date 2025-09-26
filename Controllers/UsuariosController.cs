using Inmobiliaria.Models;
using Inmobiliaria.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Inmobiliaria.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly UsuarioRepository repo = new UsuarioRepository();

        [HttpGet]
        public IActionResult Login()
        {
            // para generar un hash de prueba: 
            // Console.WriteLine(UsuarioRepository.HashPassword("1234")); 
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string clave)
        {
            // busca el usuario en la base de datos usando el email y la clave
            var usuario = repo.obtenerPorEmail(email);

            if (usuario != null && BCrypt.Net.BCrypt.Verify(clave, usuario.Clave))
            {
                // el usuario y la clave son correctos, continúa con el login
                // crea una lista de claims con el nombre, email y rol del usuario
                var claims = new List<Claim>
                    {
                    new Claim(ClaimTypes.Name, usuario.Nombre + " " + usuario.Apellido),
                    new Claim(ClaimTypes.Email, usuario.Email),
                    new Claim(ClaimTypes.Role, usuario.Rol),
                    new Claim("UserId", usuario.Id.ToString())
                    };

                // crea la identidad de claims usando autenticación por cookies
                var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // inicia sesión en la aplicación con los claims del usuario
                await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

                // redirige según el rol del usuario
                if (usuario.Rol == "Admin")
                    return RedirectToAction("PanelAdmin", "Home");
                else
                    return RedirectToAction("PanelUsuario", "Home");
            }
            else
            {
                // si la clave es incorrecta, muestra un error en la vista
                ViewBag.Error = "Email o contraseña incorrectos";
                return View();
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Usuarios");
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var lista = repo.GetAll();
            return View(lista);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Create(Usuario u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine("Modelo válido");
                    u.Clave = BCrypt.Net.BCrypt.HashPassword(u.Clave);
                    repo.Alta(u);
                    TempData["SuccessMessage"] = "Usuario creado correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    Console.WriteLine("Modelo inválido");
                    return View(u);
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al crear el usuario.";
                return View(u);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var u = repo.ObtenerPorId(id);
            if (u == null) return NotFound();
            return View(u);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    // saco el id del usuario logueado desde los claims
                    var userId = int.Parse(User.Claims.First(c => c.Type == "UserId").Value);

                    // si no es admin y quiere editar a otro => no se lo permito
                    if (u.Id != userId && !User.IsInRole("Admin"))
                    {
                        TempData["ErrorMessage"] = "No tenés permiso para editar este usuario.";
                        return RedirectToAction("Index", "Usuarios");
                    }

                    repo.Editar(u);
                    TempData["SuccessMessage"] = "Usuario editado correctamente.";

                    return RedirectToAction("Index", "Usuarios");
                }

                return View(u);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al editar el usuario.";
                Console.WriteLine("Error al editar el usuario:", ex);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var u = repo.ObtenerPorId(id);
            if (u == null) return NotFound();
            return View(u);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteConfirmed(int id)
        {
            repo.Borrar(id);
            return RedirectToAction("Index");
        }


    }
}