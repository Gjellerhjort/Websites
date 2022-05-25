using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Hackersmansion.Models;
using Hackersmansion.Data;

namespace Hackersmansion.Controllers;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private ApplicationDbContext Context { get; }
    public HomeController(ILogger<HomeController> logger, ApplicationDbContext _context)
    {
        _logger = logger;
        this.Context = _context;
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
        List<Challenge> challenges = (from challenge in this.Context.Challenge.Take(10) select challenge).ToList();
        return View(challenges);
    }

    public IActionResult Compete()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult Other()
    {   
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Other([Bind("Id,Name,Email")] Person person)
    {
        if (ModelState.IsValid)
        {
            Context.Add(person);
            await Context.SaveChangesAsync();
            return Redirect(nameof(Other));
        }   
        return View();
    }

    [HttpGet]
    public IActionResult CreateChallenge()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateChallenge([Bind("Id,Name,Email,Text,Flag")] Challenge challenge)
    {
        if (ModelState.IsValid)
        {
            Context.Add(challenge);
            await Context.SaveChangesAsync();
            return Redirect(nameof(Play));
        }   
        return View();
    }


    

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
