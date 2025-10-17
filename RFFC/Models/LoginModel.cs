using RFFC.Entities;
using System.ComponentModel.DataAnnotations;

namespace RFFC.Models;

public class LoginModel : BaseEntity
{
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
}
