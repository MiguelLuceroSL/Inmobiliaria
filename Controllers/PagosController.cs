using Inmobiliaria.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Inmobiliaria.Controllers
{
    public class PagosController : Controller
    {
        private readonly PagoRepository repo;

        public PagosController()
        {
            this.repo = new PagoRepository();
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index(int contratoId)
        {
            var lista = repo.GetByContrato(contratoId);
            ViewBag.ContratoId = contratoId;
            return View(lista);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Create(int idContrato)
        {
            var pago = new Pago { idContrato = idContrato, fechaPago = DateTime.Today };
            var contratoRepo = new ContratoRepository();
            var contrato = contratoRepo.ObtenerPorId(idContrato);
            var service = new ContratoService();
            var meses = service.CalcularMesesContrato(contrato);
            ViewBag.CuotaMensual = contrato?.cuotaMensual ?? 0;
            ViewBag.Meses = meses;
            return View(pago);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(Pago p)
        {
            if (ModelState.IsValid)
            {
                repo.Alta(p);
                return RedirectToAction("Index", new { contratoId = p.idContrato });
            }
            return View(p);
        }


        [HttpGet]
        [Authorize]
        public IActionResult Anular(int idPago, int contratoId)
        {
            try
            {
                repo.Anular(idPago, User.Identity.Name);
                TempData["SuccessMessage"] = "Pago anulado correctamente.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al anular el pago.";
            }
            return RedirectToAction("Index", new { contratoId });
        }
    }
}