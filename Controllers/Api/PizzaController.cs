using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace la_mia_pizzeria_crud_webapi.Controllers.API
{
    [Route("Guest/api/[controller]")]
    //[Route("[Page]/api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        PizzaContext db;

        public PizzaController()
        {
            db = new PizzaContext();
        }

        [HttpGet]
        public IActionResult Get()
        {
            List<Pizza> pizzes = db.Pizzas.Include("Category").ToList();

            return Ok(pizzes);
        }
    }
}