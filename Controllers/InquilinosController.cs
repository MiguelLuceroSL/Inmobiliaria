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
        public IActionResult Create(Inquilino i)
        {
            repo.Alta(i);
            return RedirectToAction("Index");
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
        public IActionResult Edit(Inquilino i)
        {
            repo.Editar(i);
            return RedirectToAction("Index");
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



