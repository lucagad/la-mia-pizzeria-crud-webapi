using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using la_mia_pizzeria_post.Models;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_crud_webapi.Controllers
{
    public class GuestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View();
        }

    }
}