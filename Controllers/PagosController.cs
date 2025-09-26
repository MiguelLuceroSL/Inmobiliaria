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
        public IActionResult Create(int contratoId)
        {
            var pago = new Pago { idContrato = contratoId, fechaPago = DateTime.Today };
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

        [HttpPost]
        [Authorize]
        public IActionResult Anular(int idPago, int contratoId)
        {
            repo.Anular(idPago);
            return RedirectToAction("Index", new { contratoId });
        }
    }
}