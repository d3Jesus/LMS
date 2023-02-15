namespace LMS.CoreBusiness.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public int Edition { get; set; }
        public int PublishingCompanyId { get; set; }
    }
}