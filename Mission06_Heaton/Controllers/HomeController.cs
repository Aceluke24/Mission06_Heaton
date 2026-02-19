using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Heaton.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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
    
    
    //Add Movie
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
    
    
    //See Movie List
    public IActionResult MovieList()
    {
        // Get all movies and include the category for display
        var movies = _context.Movies
            .Include(m => m.Category)
            .OrderBy(m => m.Title)
            .ToList();

        return View(movies);
    }

    
    //Edit Movie
    [HttpGet]
    public IActionResult EditMovie(int id)
    {
        var movie = _context.Movies
            .SingleOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        return View("AddMovie", movie); // reuse AddMovie view
    }

    [HttpPost]
    public IActionResult EditMovie(Movie updatedMovie)
    {
        if (ModelState.IsValid)
        {
            _context.Update(updatedMovie);
            _context.SaveChanges();
            return RedirectToAction("MovieList");
        }

        // Validation failed, repopulate dropdown
        ViewBag.Categories = _context.Categories
            .OrderBy(c => c.CategoryName)
            .ToList();

        return View("AddMovie", updatedMovie);
    }


    //Delete Movie
    [HttpGet]
    public IActionResult DeleteMovie(int id)
    {
        var movie = _context.Movies
            .SingleOrDefault(m => m.MovieId == id);

        if (movie == null)
        {
            return NotFound();
        }

        return View(movie);
    }

    [HttpPost]
    public IActionResult DeleteMovieConfirmed(int MovieId)
    {
        var movie = _context.Movies
            .SingleOrDefault(m => m.MovieId == MovieId);

        if (movie != null)
        {
            _context.Movies.Remove(movie);
            _context.SaveChanges();
        }

        return RedirectToAction("MovieList");
    }


    
}
