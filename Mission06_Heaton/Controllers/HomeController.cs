using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Heaton.Models;

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
        return View("AddMovie");
    }

    [HttpPost]
    public IActionResult AddMovie(Movie response)
    {
        _context.Movies.Add(response);
        _context.SaveChanges();
        
        return View();
    }
    
}
