using Inmobiliaria.Models;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Controllers
{
    public class ContratosController : Controller
    {
        private readonly ContratoRepository repo;

        public ContratosController()
        {
            this.repo = new ContratoRepository();
        }

        public IActionResult Index()
        {
            var lista = this.repo.GetAllConDetalles();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var inmuebles = new InmuebleRepository().GetAll();
            ViewBag.Inmuebles = inmuebles;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Contrato c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Alta(c);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(c);
                }
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                ModelState.AddModelError(string.Empty, "Ocurrió un error al crear el contrato.");
                return View(c);
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contrato = repo.ObtenerPorId(id);
            if (contrato == null)
            {
                return NotFound();
            }
            return View(contrato);
        }

        [HttpPost]
        public IActionResult Edit(Contrato c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Editar(c);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(c);
                }
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                ModelState.AddModelError(string.Empty, "Ocurrió un error al editar el contrato.");
                return View(c);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contrato = repo.ObtenerPorId(id);
            if (contrato == null)
            {
                return NotFound();
            }
            return View(contrato);
        }

        [HttpPost]
        public IActionResult Delete(Contrato c)
        {
            try
            {
                repo.Borrar(c.idContrato);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                ModelState.AddModelError(string.Empty, "Ocurrió un error al eliminar el contrato.");
                return View(c);
            }
        }
    }
}