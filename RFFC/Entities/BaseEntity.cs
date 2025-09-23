using System.ComponentModel.DataAnnotations;

namespace RFFC.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid RFCId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
