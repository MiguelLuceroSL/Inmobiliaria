using Inmobiliaria.Models;
using Inmobiliaria.Repositories;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
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
            var usuario = repo.Login(email, clave);

            if (usuario == null)
            {
                ViewBag.Error = "Email o contraseña incorrectos";
                return View();
            }

            // Claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Nombre + " " + usuario.Apellido),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            //redirección según rol
            if (usuario.Rol == "admin")
                return RedirectToAction("PanelAdmin", "Home");
            else
                return RedirectToAction("Panel", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Usuarios");
        }
    

     public IActionResult Index()
        {
            var lista = repo.GetAll();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Usuario u)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Alta(u);
                    TempData["SuccessMessage"] = "Usuario creado correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
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
        public IActionResult Edit(int id)
        {
            var u = repo.ObtenerPorId(id);
            if (u == null) return NotFound();
            return View(u);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Usuario u)
        {
            try
            {
                if (ModelState.IsValid)
                {
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
        public IActionResult Delete(int id)
        {
            var u = repo.ObtenerPorId(id);
            if (u == null) return NotFound();
            return View(u);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            repo.Borrar(id);
            return RedirectToAction("Index");
        }


    }
}