

using System.ComponentModel.DataAnnotations.Schema;

namespace RFFC.Entities
{
    [Table("RFC")]
    public class RFC : BaseEntity
    {
        [Column("Name")]
        public string Name { get; set; }
        [Column("SurName")]
        public string SurName { get; set; }
        [Column("Email")]
        public string Email { get; set; }
        [Column("PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Column("Address")]
        public string Address { get; set; }
        [Column("Status")]
        public string Status { get; set; }
    }
}
