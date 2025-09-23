using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;

namespace Inmobiliaria.Controllers
{
    public class InquilinosController : Controller
    {
        private InquilinoRepository repo = new InquilinoRepository();

        // public IActionResult Index()
        // {
        //     var lista = repo.GetAll();
        //     return View(lista);
        // }
         public IActionResult Index(int pagina = 1)
        {

             int tamPagina = 10;
           
            var lista = repo.ObtenerListaInquilinos(pagina, tamPagina);
            // Calcular total de páginas (ejemplo básico, ajusta según tu lógica)
            int totalRegistros = repo.ContarInquilinos(); // Este método debe contar los registros totales
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / tamPagina);

            ViewBag.Pagina = pagina;
            ViewBag.TotalPaginas = totalPaginas;
            return View(lista);
         }



        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

       [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Inquilino i)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Alta(i);
                    TempData["SuccessMessage"] = "Inquilino creado correctamente.";
                    return RedirectToAction("Index", "Inquilinos");
                }

                TempData["ErrorMessage"] = "Los datos ingresados no son válidos.";
                return View(i);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al crear el inquilino.";
                Console.WriteLine("Error al crear el inquilino:", ex);
                return RedirectToAction("Index");
            }
        }


        [HttpGet]
        public IActionResult Buscar(string term, int offset = 0, int limit = 20)
        {
            var repo = new InquilinoRepository();
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
      [ValidateAntiForgeryToken]
        public IActionResult Edit(Inquilino i)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Editar(i);
                    TempData["SuccessMessage"] = "Inquilino editado correctamente.";
                    return RedirectToAction("Index", "Inquilinos");
                }
                return View(i);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al editar el inquilino.";
                Console.WriteLine("Error al editar el inquilino:", ex);
                return RedirectToAction("Index");
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var i = repo.ObtenerPorId(id);
            if (i == null) return NotFound();
            return View(i);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            repo.Borrar(id);
            return RedirectToAction("Index");
        }
    }
}



