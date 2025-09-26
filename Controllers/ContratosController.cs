using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize]
        public IActionResult Index()
        {
            var lista = this.repo.GetAllConDetalles();
            return View(lista);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            /*var inmuebles = new InmuebleRepository().GetAll();
            ViewBag.Inmuebles = inmuebles;
            var inquilinos = new InquilinoRepository().GetAll();
            ViewBag.Inquilinos = inquilinos;*/
            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Contrato c)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //debo setearlo logica
                    c.estadoContrato = "Activo";
                    c.alDia = true;
                    c.fechaRescision = null;
                    c.canceladoPor = "";

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
        [Authorize]
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
        [Authorize]
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
        [Authorize]
        public IActionResult Detalles(int id)
        {
            var contrato = repo.ObtenerPorId(id);

            var inqRepo = new InquilinoRepository();
            var inmuebleRepo = new InmuebleRepository();

            var inquilino = inqRepo.ObtenerPorId(contrato.idInquilino);
            var inmueble = inmuebleRepo.ObtenerPorId(contrato.idInmueble);

            var pagosRepo = new PagoRepository();
            var pagosRealizados = pagosRepo.ContarPagosPorContrato(id);

            var service = new ContratoService();

            var mesesContrato = service.CalcularMesesContrato(contrato);
            var pagosEsperados = service.CalcularPagosEsperados(contrato);
            var alDia = pagosEsperados <= pagosRealizados;


            ViewBag.MesesContrato = mesesContrato;
            ViewBag.CuotaMensual = contrato.cuotaMensual;
            ViewBag.PagosEsperados = pagosEsperados;
            ViewBag.NombreInquilino = $"{inquilino.nombre} {inquilino.apellido}";
            ViewBag.DireccionInmueble = inmueble.direccion;
            ViewBag.PagosRealizados = pagosRealizados;
            ViewBag.AlDia = alDia;

            return View(contrato);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(Contrato c)
        {
            try
            {
                repo.cancelarContrato(c.idContrato, User.Identity.Name);
                TempData["SuccessMessage"] = "Contrato cancelado correctamente.";
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