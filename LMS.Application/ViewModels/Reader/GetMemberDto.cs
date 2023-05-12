namespace LMS.Application.ViewModels.Reader
{
    public class GetMemberDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string DocNumber { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }
}
