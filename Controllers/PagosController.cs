using Inmobiliaria.Models;
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

        public IActionResult Index(int contratoId)
        {
            var lista = repo.GetByContrato(contratoId);
            ViewBag.ContratoId = contratoId;
            return View(lista);
        }

        [HttpGet]
        public IActionResult Create(int contratoId)
        {
            var pago = new Pago { idContrato = contratoId, fechaPago = DateTime.Today };
            return View(pago);
        }

        [HttpPost]
        public IActionResult Create(Pago p)
        {
            if (ModelState.IsValid)
            {
                repo.Alta(p);
                return RedirectToAction("Index", new { contratoId = p.idContrato });
            }
            return View(p);
        }

        public IActionResult Anular(int idPago, int contratoId)
        {
            repo.Anular(idPago);
            return RedirectToAction("Index", new { contratoId });
        }
    }
}