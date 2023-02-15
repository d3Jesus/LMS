using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Bookcase
{
    public class AddBookcaseViewModel
    {
        [Required]
        public string Section { get; set; } = string.Empty;
        [Required]
        public string Hall { get; set; } = string.Empty;
    }
}
