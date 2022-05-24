using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hackersmansion.Models;

namespace Hackersmansion.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Dashboard()
    {
        return View();
    }

    public IActionResult Learn()
    {
        return View();
    }
    public IActionResult Play()
    {
        return View();
    }

    public IActionResult Compete()
    {
        return View();
    }

    [HttpGet]
    public ViewResult Other()
    { 
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
