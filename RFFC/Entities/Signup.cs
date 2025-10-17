using System.ComponentModel.DataAnnotations.Schema;

namespace RFFC.Entities;

[Table("Users")]
public class User : BaseEntity
{
    [Column("Email")]
    public string Email { get; set; }

    [Column("PasswordHash")]
    public string PasswordHash { get; set; }

    [Column("Message")]
    public string? Message { get; set; }
}
