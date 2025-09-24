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
    }
}