using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Heaton.Models;
using System.Linq;
using SQLitePCL;


namespace Mission06_Heaton.Controllers;

public class HomeController : Controller
{
    
    private MovieContext _context;
    
    public HomeController(MovieContext temp)
    {
        _context = temp;
    }
    
    
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }


    [HttpGet]
    public IActionResult AddMovie()
    {
        // Populate categories as a list for the dropdown
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        // Pass a new Movie object to the view
        return View("AddMovie", new Movie());
    }

    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        if (ModelState.IsValid)
        {
            _context.Movies.Add(response); //Add record to database
            _context.SaveChanges();

            // Keep user on the same page after submission
            // Option 1: return the same view with a fresh Movie object
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            // Optionally, you can add a success message via ViewBag
            ViewBag.Message = "Movie added successfully!";

            return View("AddMovie", new Movie());
        }
        else
        {
            // Repopulate the dropdown if validation fails
            ViewBag.Categories = _context.Categories
                .OrderBy(c => c.CategoryName)
                .ToList();

            return View(response);
        }
    }
    
}
