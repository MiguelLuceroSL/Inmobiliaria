using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    public class PropietariosController : Controller
    {
        private readonly PropietarioRepository repo;

        public PropietariosController()
        {
            this.repo = new PropietarioRepository();
        }

        public IActionResult Index()
        {
            var lista = this.repo.GetAll();
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
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Alta(p);
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
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el propietario.");
                return View(p);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var p = repo.ObtenerPorId(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost]
        public IActionResult Edit(Propietario p)
        {
            repo.Editar(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var p = repo.ObtenerPorId(id);
            if (p == null) return NotFound();
            return View(p);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            repo.Borrar(id);
            return RedirectToAction("Index");
        }

        /*[HttpGet] //con ajax
        [Route("[controller]/Buscar/{query}", Name = "Buscar")]
        public IActionResult Buscar(string query)
        {
            try
            {
                var res = repo.BuscarPorNombre(query);
                return Json(new { Datos = res });
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                return Json(new { Error = "Ocurrió un error al buscar el propietario.", ex.Message });
            }
        }*/
    }
}