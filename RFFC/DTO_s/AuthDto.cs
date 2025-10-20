using System.ComponentModel.DataAnnotations;

namespace RFFC.DTO_s
{
    public class AuthDto
    {
        // 🔐 Login DTO
        public class Login
        {
            [Required]
            public string Username { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required]
            public string Password { get; set; }
        }

        public class LoginResponse
        {
            public string Token { get; set; }
            public string Message { get; set; }
        }

        // 📝 Signup DTO
        public class Signup
        {
            [Required]
            public string Username { get; set; }

            [Required, EmailAddress]
            public string Email { get; set; }

            [Required, MinLength(6)]
            public string Password { get; set; }

            public string? Message { get; set; }
        }

        public class SignupResponse
        {
            public string Message { get; set; }
        }
    }
}
