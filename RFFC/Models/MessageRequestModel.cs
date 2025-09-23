using RFFC.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RFFC.Models
{
    public class MessageRequestModel : BaseEntity
    {
        [Required]
        public string MessageText { get; set; }
        [Required]
        public string RecipientName { get; set; }
        [Required]
        public string RecipientPhone { get; set; }
        [Required]
        public string RecipientEmail { get; set; }
    }
}
