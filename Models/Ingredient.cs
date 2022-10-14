using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using la_mia_pizzeria_post;

namespace la_mia_pizzeria_post.Models;

[Table("ingredient")]
public class Ingredient
{
    [Key]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Il campo è obbligatorio")]
    [StringLength (50, ErrorMessage = "Il nome non può avere più di 50 caratteri")]
    public string Name { get; set; }
    
    public List<Pizza> Pizzas { get; set; }
    
    public Ingredient()
    {
        
    }
    
}