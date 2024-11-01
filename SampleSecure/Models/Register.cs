using System.ComponentModel.DataAnnotations;

namespace SampleSecure.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Username harus diisi.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password harus diisi.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password harus terdiri dari minimal 8 karakter.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W_]).{8,}$", 
            ErrorMessage = "Password harus memiliki setidaknya satu huruf besar, satu huruf kecil, satu angka, dan satu karakter khusus.")]
        public required string Password { get; set; }
    }
}
