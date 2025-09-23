using System.ComponentModel.DataAnnotations.Schema;

namespace RFFC.Entities
{
    [Table("MessageRequest")]
    public class MessageRequest : BaseEntity
    {
        
        [Column("MessageText")]
        public string MessageText { get; set; }

        [Column("RecipientName")]
        public string RecipientName { get; set; }

        [Column("RecipientPhone")]
        public string RecipientPhone { get; set; }

        [Column("RecipientEmail")]
        public string RecipientEmail { get; set; }
    }
}
