using System.ComponentModel.DataAnnotations;

namespace api_pokelab.Models
{
    public class User
    {
        [Key]
        [Required]
        [EmailAddress]
        public required string Email { get; set; } 

        [Required]
        public required string PasswordHash { get; set; }

        [Required]
        public required string Username { get; set; }

      
    }

}
