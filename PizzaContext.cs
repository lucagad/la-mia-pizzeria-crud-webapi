using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class PizzaContext : IdentityDbContext<IdentityUser>
{
    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Message> Messages { get; set; }
    
    public PizzaContext()
    {

    }

    public PizzaContext(DbContextOptions<PizzaContext> options)
        : base(options)
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Data Source=localhost;Initial Catalog=db_pizzeria;Persist Security Info=True;User ID=sa;Password=NET2022!");
    }
    
}