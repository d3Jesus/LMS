using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Book
{
    public class AddBookDto
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public int PublicationYear { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public int PublishingCompanyId { get; set; }
        [Required]
        public int Edition { get; set; }
    }
}
