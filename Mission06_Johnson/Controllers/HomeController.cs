using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Johnson.Models;

namespace Mission06_Johnson.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    public IActionResult Movies()
    {
        return View();
    }

    
}