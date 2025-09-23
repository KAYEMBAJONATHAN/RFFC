using RFFC.Entities;
using System.ComponentModel.DataAnnotations;

namespace RFFC.Models
{
    public class RFCMember : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]  
        public string Address { get; set; }
        [Required]
        public string Status { get; set; }
    }
}
