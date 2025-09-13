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
                    TempData["SuccessMessage"] = "Contrato creado correctamente.";
                    return RedirectToAction("Index", "Contratos");
                }
                else
                {
                    return View(c);
                }
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                TempData["ErrorMessage"] = "Ocurrió un error al crear el contrato.";
                return RedirectToAction("Index", "Contratos");
            }
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var contrato = repo.ObtenerPorId(id);
            var inmuebles = new InmuebleRepository().GetAll();
            var inquilinos = new InquilinoRepository().GetAll();
            ViewBag.Inquilinos = inquilinos;
            ViewBag.Inmuebles = inmuebles;

            if (contrato == null)
            {
                return NotFound();
            }
            return View(contrato);
        }

        [HttpPost]
        public IActionResult Edit(Contrato c)
        {

            Console.WriteLine($"Editando contrato: {System.Text.Json.JsonSerializer.Serialize(c)}");
            try
            {
                if (ModelState.IsValid)
                {
                    repo.Editar(c);
                    TempData["SuccessMessage"] = "Contrato editado correctamente.";
                    return RedirectToAction("Index", "Contratos");
                }
                else
                {
                    return View(c);
                }
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                TempData["ErrorMessage"] = "Ocurrió un error al editar el contrato.";
                return RedirectToAction("Index", "Contratos");
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
                TempData["SuccessMessage"] = "Contrato eliminado correctamente.";
                return RedirectToAction("Index", "Contratos");
            }
            catch (Exception ex)
            {
                //registramos la excepción en ex
                TempData["ErrorMessage"] = "Ocurrió un error al eliminar el contrato.";
                return RedirectToAction("Index", "Contratos");
            }
        }
    }
}