using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Johnson.Models;

namespace Mission06_Johnson.Controllers;

public class HomeController : Controller
{
    
    private MovieFormContext _context;
    public HomeController(MovieFormContext temp)
    {
        _context = temp;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnowJoel()
    {
        return View();
    }
    
    [HttpGet]
    public IActionResult MovieForm()
    {
        return View();
    }

    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        return View("Confirmation", response);
    }
}

  