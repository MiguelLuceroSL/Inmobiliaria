using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PruebaDotNETMVC.Models;

namespace PruebaDotNETMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    // Página pública
    public IActionResult Index()
    {
        return View();
    }

    [Authorize]
    public IActionResult PanelUsuario()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    //vista restringida, solo usuarios logueados pueden entrar
    [Authorize]
    public IActionResult Panel()
    {
        return View();
    }

    public IActionResult Restringido()
    {
        return View();
    }

    //vista restringida solo para Admin
    [Authorize(Roles = "Admin")]
    public IActionResult PanelAdmin()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
