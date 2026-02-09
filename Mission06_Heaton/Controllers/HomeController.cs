using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Mission06_Heaton.Models;

namespace Mission06_Heaton.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult GetToKnow()
    {
        return View();
    }

    public IActionResult AddMovie()
    {
        return View();
    }
    
}