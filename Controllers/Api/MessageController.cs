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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
       
        [HttpPost]
        public IActionResult Send([FromBody] Message message)
        {
           
            PizzaContext ctx = new PizzaContext();

            ctx.Messages.Add(message);
            ctx.SaveChanges();

            return Ok();
        }
        
    }
}