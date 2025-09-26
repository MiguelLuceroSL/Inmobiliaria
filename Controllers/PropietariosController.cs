using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;

namespace Inmobiliaria.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly PropietarioRepository repo;

        public PropietariosController()
        {
            this.repo = new PropietarioRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            var lista = this.repo.GetAll();
            return View(lista);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Propietario p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Alta(p);
                    TempData["SuccessMessage"] = "Propietario creado correctamente.";
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(p);
                }
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                // ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el .");
                TempData["ErrorMessage"] = "Ocurrió un error al crear el propietario.";
                return View(p);
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Edit(int id)
        {
            var p = repo.ObtenerPorId(id);
            if (p == null) return NotFound();
            return View(p);
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Propietario p)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Editar(p);
                    TempData["SuccessMessage"] = "Propietario editado correctamente.";
                    return RedirectToAction("Index", "Propietarios");
                }
                return View(p);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al editar el propietario.";
                Console.WriteLine("Error al editar el propietario:", ex);
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var p = repo.ObtenerPorId(id);
            if (p == null) return NotFound();
            return View(p);
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