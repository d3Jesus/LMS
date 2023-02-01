using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Author
{
    public class AddAuthorViewModel
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Nationality { get; set; } = string.Empty;
    }
}
