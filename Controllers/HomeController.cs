using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_post.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_post.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Pizza> pizzes;

        using (PizzaContext db = new PizzaContext())
        {
            pizzes = db.Pizzas.Include("Category").ToList();
        }
        
        return View("Index", pizzes);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}