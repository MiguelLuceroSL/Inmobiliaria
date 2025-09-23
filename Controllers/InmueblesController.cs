using Microsoft.AspNetCore.Mvc;
using Inmobiliaria.Models;
using MySql.Data.MySqlClient;


namespace Inmobiliaria.Controllers
{
    public class InmueblesController : Controller
    {
        private InmuebleRepository repo = new InmuebleRepository();
        private PropietarioRepository repoPropietarios = new PropietarioRepository();

        public IActionResult Index(int pagina = 1)
        {

             int tamPagina = 10;
            //var repo = new InmuebleRepository();
            var lista = repo.ObtenerListaInmuebles(pagina, tamPagina);

            // Calcular total de páginas (ejemplo básico, ajusta según tu lógica)
            int totalRegistros = repo.ContarInmuebles(); // Este método debe contar los registros totales
            int totalPaginas = (int)Math.Ceiling((double)totalRegistros / tamPagina);

            ViewBag.Pagina = pagina;
            ViewBag.TotalPaginas = totalPaginas;

            return View(lista);



            //  var lista = repo.GetAll();
           //var lista = repo.ObtenerListaInmuebles();
            //return View(lista);
            //      int tamaño = 5; // cantidad de inmuebles por página
            //      var lista = repo.Lista(pagina, tamaño); // método paginado

            //     ViewBag.Pagina = pagina;
            //     int total = repo.ObtenerCantidad(); // total de registros
            //     ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamaño);

            //     return View(lista);
            // }

            // public IActionResult Index()
            // {
            //     var lista = repo.GetAll();
            //     return View(lista);
            //     //      int tamaño = 5; // cantidad de inmuebles por página
            //     //      var lista = repo.Lista(pagina, tamaño); // método paginado

            //     //     ViewBag.Pagina = pagina;
            //     //     int total = repo.ObtenerCantidad(); // total de registros
            //     //     ViewBag.TotalPaginas = (int)Math.Ceiling((double)total / tamaño);

            //     //     return View(lista);
            //     // 
            //
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
                TempData["SuccessMessage"] = "Inmueble creado correctamente.";
                return RedirectToAction("Index", "Inmuebles");
            }
            return View(i);
        }
   

        // [HttpGet]
        // // public IActionResult Buscar(string term, int offset = 0, int limit = 20)
        // // {
        // //     var repo = new InmuebleRepository();
        // //     var resultados = repo.Buscar(term, offset, limit);
        // //     return Json(resultados);
        // // }

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
            Console.WriteLine("Controller id Propietario: " + i.idPropietario);
            try
            {
                if (ModelState.IsValid)
                {   
                    repo.Editar(i);
                    TempData["SuccessMessage"] = "Inmueble editado correctamente.";
                    return RedirectToAction("Index", "Inmuebles");
                }
                return View(i);
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                TempData["ErrorMessage"] = "Ocurrió un error al editar el inmueble.";
                Console.WriteLine("Error al editar el inmueble:", ex);
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        public IActionResult BuscarPropietarios(string filtro, int offset = 0, int limit = 10)
        {
            var lista = repoPropietarios.Buscar(filtro, offset, limit);
            return Json(lista);
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
