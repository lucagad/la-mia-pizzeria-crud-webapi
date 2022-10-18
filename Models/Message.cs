using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace la_mia_pizzeria_post.Models;

    [Table("message")]
    public class Message
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Il campo è obbligatorio")]
        public string Text { get; set; }
        
        public Message()
        {

        }
    }
