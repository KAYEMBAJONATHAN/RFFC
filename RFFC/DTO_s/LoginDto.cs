using System.ComponentModel.DataAnnotations;

namespace RFFC.DTO_s;

public class LoginDto
{
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}

public class LoginResponseDto
{
    public string Token { get; set; }
    public string Message { get; set; }
}
