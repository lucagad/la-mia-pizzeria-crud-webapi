using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace la_mia_pizzeria_post.Controllers;

/*[Authorize]*/
public class PizzaController : Controller
{
    public IActionResult Index()
    {
        List<Pizza> pizzes;

        using (PizzaContext db = new PizzaContext())
        {
            pizzes = db.Pizzas.Include("Category").ToList();
        }

        return View("Index", pizzes);
    }

    public IActionResult Show(int id)
    {
        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaFound = context.Pizzas.Where(pizza => pizza.PizzaId == id).Include(pizza => pizza.Category).FirstOrDefault();
            
            if (pizzaFound == null)
            {
                return NotFound($"La Pizza con id {id} non è stata trovata");
            }
            else
            {
                return View("Show", pizzaFound);
            }
        }
    }
    
    [HttpGet]
    public IActionResult Create()
    {
        PizzasCategories pizzasCategories = new PizzasCategories();
        
        pizzasCategories.Categories = new PizzaContext().Categories.ToList();
        pizzasCategories.Ingredients = new PizzaContext().Ingredients.ToList();
        return View("Create",pizzasCategories);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(PizzasCategories formData)
    {
        if (!ModelState.IsValid)
        {
            PizzasCategories pizzasCategories = new PizzasCategories();
            pizzasCategories.Categories = new PizzaContext().Categories.ToList();
            pizzasCategories.Ingredients = new PizzaContext().Ingredients.ToList();
            return View("Create", pizzasCategories);
        }

        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaToCreate = new Pizza();
            
            pizzaToCreate.Name = formData.Pizza.Name;
            pizzaToCreate.Description = formData.Pizza.Description;
            
            if (formData.Pizza.ImgUrl != null)
            {
                pizzaToCreate.ImgUrl = formData.Pizza.ImgUrl;
            }
            else
            {
                pizzaToCreate.ImgUrl="/img/placeholder.jpg";
            }
            
            pizzaToCreate.Price = formData.Pizza.Price;
            pizzaToCreate.CategoryId = formData.Pizza.CategoryId;
            
            pizzaToCreate.Ingredients = context.Ingredients.Where(ingredient => formData.SelectedIngredients.Contains(ingredient.Id)).ToList<Ingredient>();
            context.Pizzas.Add(pizzaToCreate);
            context.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    [HttpGet]
    public IActionResult Update(int id)
    {
        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaSelected = context.Pizzas.Include("Category").Include("Ingredients")
                .Where(pizza => pizza.PizzaId == id).First();
            
            if (pizzaSelected == null)
            {
                return NotFound("Pizza non trovata");
            }
            
            PizzasCategories pizzasCategories = new PizzasCategories();
            pizzasCategories.Pizza = pizzaSelected;
            pizzasCategories.Categories = new PizzaContext().Categories.ToList();
            pizzasCategories.Ingredients = new PizzaContext().Ingredients.ToList();

            return View (pizzasCategories);
        }
    }

    [HttpPost]
    public IActionResult Update(int id, PizzasCategories formData)
    {
        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizzaSelected = context.Pizzas.Where(pizza => pizza.PizzaId == id).Include("Ingredients").FirstOrDefault();
            
            pizzaSelected.Name = formData.Pizza.Name;
            pizzaSelected.Description = formData.Pizza.Description;
            pizzaSelected.ImgUrl = formData.Pizza.ImgUrl;
            pizzaSelected.Price = formData.Pizza.Price;
            pizzaSelected.CategoryId = formData.Pizza.CategoryId;
            
            pizzaSelected.Ingredients = context.Ingredients.Where(ingredient => formData.SelectedIngredients.Contains(ingredient.Id)).ToList<Ingredient>();
            
            context.Pizzas.Update(pizzaSelected);
          
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id)
    {
        using (PizzaContext context = new PizzaContext())
        {
            Pizza pizza = context.Pizzas.Where(Pizza => Pizza.PizzaId == id).FirstOrDefault();
            if (pizza == null)
            {
               return NotFound("Non trovato");
            }
            context.Pizzas.Remove(pizza);
            context.SaveChanges();
            return RedirectToAction("Index");
        }   
    }
}