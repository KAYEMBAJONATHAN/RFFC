using System.ComponentModel.DataAnnotations.Schema;

namespace RFFC.DTO_s
{
    public class MessageRequestDto
    {

        public string MessageText { get; set; }
        public string RecipientName { get; set; }

        public string RecipientPhone { get; set; }
        public string RecipientEmail { get; set; }
    }
}
