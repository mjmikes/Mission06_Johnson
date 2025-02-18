using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();
        return View();
    }

    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        return View("Confirmation", response);
    }
    public IActionResult MovieList()
    {
        // LINQ query to filter and order movies
        var movies = _context.Movies
            //.Include(x => x.Movie2)
            .Where(x => x.Edited == false) 
            .OrderBy(x => x.Title).ToList();

        return View(movies); // Pass the movies to the view
    }

}

  