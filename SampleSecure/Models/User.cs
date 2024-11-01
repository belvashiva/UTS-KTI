using System.ComponentModel.DataAnnotations;

namespace SampleSecure.Models
{
    public class User
    {
        public int Id { get; set; } // Misalnya, untuk auto-increment primary key
        [Required]
        public required string Username { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
