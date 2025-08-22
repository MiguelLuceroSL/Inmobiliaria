using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    public class PropietariosController : Controller
    {
        private PropietarioRepository repo = new PropietarioRepository();

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
        public IActionResult Create(Propietario p)
        {
            repo.Alta(p);
            return RedirectToAction("Index");
        }
    }
}