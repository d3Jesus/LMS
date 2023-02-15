using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Authorship
{
    public class AddAuthorshipViewModel
    {
        [Required]
        public int AuthorId { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
