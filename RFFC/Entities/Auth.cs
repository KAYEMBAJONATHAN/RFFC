using System.ComponentModel.DataAnnotations.Schema;

namespace RFFC.Entities
{
    [Table("Auth")]
    public class Auth : BaseEntity
    {
        [Column("Username")]
        public string Username { get; set; }

        [Column("Email")]
        public string Email { get; set; }

        [Column("PasswordHash")]
        public string PasswordHash { get; set; }

        [Column("Message")]
        public string? Message { get; set; }
    }
}
