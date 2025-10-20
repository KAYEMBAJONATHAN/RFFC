using System.ComponentModel.DataAnnotations;

namespace RFFC.Models
{
    public class AuthModel
    {
        [Required]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, MinLength(6)]
        public string Password { get; set; }

        public string? Message { get; set; }

        public bool IsSignup { get; set; } // true = signup, false = login
    }
}