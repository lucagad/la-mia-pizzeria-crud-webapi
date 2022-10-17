using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

/*
[HttpGet]
public IActionResult Get()
{
    List<Pizza> pizzes = db.Pizzas.Include("Category").ToList();

    return Ok(pizzes);
}
*/

namespace la_mia_pizzeria_crud_webapi.Controllers.API
{
    //api/Pizza
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        PizzaContext _ctx;
        public PizzaController()
        {
            _ctx = new PizzaContext();
        }
        
        //api/Pizza
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Pizza> pizzes = _ctx.Pizzas.Include("Category").ToList();

            return Ok(pizzes);
        }
        
        //api/Pizza/GetByName
        [HttpGet()]
        public IActionResult GetByName(string? name)
        {
            IQueryable<Pizza> pizzas;

            if(name != null){
                
                pizzas = _ctx.Pizzas.Where(pizza => pizza.Name.ToLower().Contains(name.ToLower()));
            }
            else
            {
                pizzas = _ctx.Pizzas;
            }

            return Ok(pizzas.ToList());
        }

       
        //api/Pizza/get/[qualqune numero]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Pizza pizza = _ctx.Pizzas.Where(pizza => pizza.PizzaId == id).Include("Category").FirstOrDefault();

            return Ok(pizza);
        }

       
    }
}