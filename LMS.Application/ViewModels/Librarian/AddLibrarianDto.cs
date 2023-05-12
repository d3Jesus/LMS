using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Librarian
{
    public class AddLibrarianDto
    {
        [Required]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public string Address { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
    }
}
