using System.ComponentModel.DataAnnotations.Schema;

namespace RFFC.Entities
{
    [Table("Login")]
    public class Login : BaseEntity
    {
        [Column("Email")]
        public string Email { get; set; }
        [Column("Password")]
        public string Password { get; set; }
    }
}
