using System.ComponentModel.DataAnnotations;

namespace RFFC.DTO_s;

public class SignupDto
{
    [Required, EmailAddress]
    public string Email { get; set; }

    [Required, MinLength(6)]
    public string Password { get; set; }

    public string? Message { get; set; }
}

public class SignupResponseDto
{
    public string Message { get; set; }
}
