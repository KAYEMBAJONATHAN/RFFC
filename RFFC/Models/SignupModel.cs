using Microsoft.Build.Framework;
using RFFC.Entities;

namespace RFFC.Models;

public class SignupModel : BaseEntity
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Message { get; set; }
}
