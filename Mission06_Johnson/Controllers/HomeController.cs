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
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View(new Movie());
    }

    [HttpPost]
    public IActionResult MovieForm(Movie response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }

    public IActionResult MovieList()
    {
        var movies = _context.Movies.Include(m => m.Category).OrderBy(m => m.Title).ToList();
        return View(movies);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        var recordToEdit = _context.Movies.Single(x => x.MovieId == id);
        ViewBag.Categories = _context.Categories.OrderBy(c => c.CategoryName).ToList();
        return View("MovieForm", recordToEdit);
    }
    
    [HttpPost]
    public IActionResult Edit(Movie updatedInfo)
    {
        _context.Entry(updatedInfo).State = EntityState.Modified; // ✅ Explicitly mark as an update
        _context.SaveChanges();

        return RedirectToAction("MovieList");
    }
    
    [HttpGet]
    public IActionResult Delete(int id)
    {
        var recordToDelete = _context.Movies.Single(x => x.MovieId == id);
        return View(recordToDelete);
    }
    
    [HttpPost]
    public IActionResult Delete(Movie deletedInfo)
    {
        _context.Movies.Remove(deletedInfo);
        _context.SaveChanges();
        
        return RedirectToAction("MovieList");
    }
}