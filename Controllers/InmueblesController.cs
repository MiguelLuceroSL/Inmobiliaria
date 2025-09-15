using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;
using MySql.Data.MySqlClient;


namespace Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private InmuebleRepository repo = new InmuebleRepository();

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
        public IActionResult Create(Inmueble i)
        {
            if (ModelState.IsValid)
            {
                repo.Alta(i);
                return RedirectToAction("Index");
            }
            return View(i);
        }

        [HttpGet]
        public IActionResult Buscar(string term, int offset = 0, int limit = 20)
        {
            var repo = new InmuebleRepository();
            var resultados = repo.Buscar(term, offset, limit);
            return Json(resultados);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var i = repo.ObtenerPorId(id);
            if (i == null) return NotFound();
            return View(i);
        }

        [HttpPost]
        public IActionResult Edit(Inmueble i)
        {
            if (ModelState.IsValid)
            {
                repo.Editar(i);
                return RedirectToAction("Index");
            }
            return View(i);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var i = repo.ObtenerPorId(id);
            if (i == null) return NotFound();
            return View(i);
        }

        [HttpPost]
// [ValidateAntiForgeryToken]
// public IActionResult Delete(int id)
// {
//     try
//     {
//         var repo = new InmuebleRepository();
//         repo.Borrar(id);

//         TempData["SuccessMessage"] = "Inmueble eliminado correctamente";
//         return RedirectToAction("Index");
//     }
//     catch (MySqlException ex)
//     {
//         if (ex.Number == 1451) // Código de restricción FK
//         {
//             TempData["ErrorMessage"] = "No se puede eliminar el inmueble porque tiene contratos asociados.";
//             var inmueble = repo.ObtenerPorId(id);
//             return View(inmueble);
//         }
//         throw; // otros errores los relanzamos
//     }
// }


        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            repo.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}
