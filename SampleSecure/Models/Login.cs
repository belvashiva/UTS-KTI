using System.ComponentModel.DataAnnotations;

namespace SampleSecure.Models // Ganti dengan namespace yang sesuai
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username harus diisi.")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Password harus diisi.")]
        public required string Password { get; set; }
    }
}
