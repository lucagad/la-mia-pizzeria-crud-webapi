using la_mia_pizzeria_post.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PizzaContextConnection") ?? throw new InvalidOperationException("Connection string 'PizzaContextConnection' not found.");

builder.Services.AddDbContext<PizzaContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<PizzaContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

#if DEBUG
builder.Services.AddSassCompiler();
#endif

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Guest}/{action=Index}/{id?}");

app.MapRazorPages();
app.Run();

//defaultValue();


static void defaultValue()
{
    
    using (PizzaContext db = new PizzaContext()) 
    {
     
        // Creazione Pizze
        db.Add(new Pizza { PizzaId = 1, Name = "Pizza Margherita", Description = "Pizza con Pomodoro e Mozzarella", ImgUrl= "/img/pizza_margherita.jpg",Price = 6 });
        db.Add(new Pizza { PizzaId = 2, Name = "Pizza Wurstel", Description = "Pizza con Pomodoro, Mozzarella e Wurstel", ImgUrl= "/img/pizza_wurstel.jpg",Price = 8 });
        db.Add(new Pizza { PizzaId = 3, Name = "Pizza 4 Stagioni", Description = "Pizza con Pomodoro, Mozzarella, Carciofini, Funghi, Olive e Prosciutto Cotto", ImgUrl= "/img/pizza_quattro_stagioni.jpg",Price = 9 });
        
        db.SaveChanges();
            
        Console.WriteLine("Dati Inseriti");
            
    }
}