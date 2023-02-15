namespace LMS.CoreBusiness.Entities
{
    public class PublishingCompany : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
