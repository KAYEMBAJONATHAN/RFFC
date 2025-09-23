namespace RFFC.DTO_S
{
    public class RFCMemberDto
    {
        public Guid RFCId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string Email { get; set; }

        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Status { get; set; }
    }
}
