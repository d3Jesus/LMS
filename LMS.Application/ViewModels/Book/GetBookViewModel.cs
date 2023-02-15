namespace LMS.Application.ViewModels.Book
{
    public class GetBookViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }
        public int PublishingCompanyId { get; set; }
        public int Edition { get; set; }
    }
}
