using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Request
{
    public class AddLoanDto
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int ReaderId { get; set; }
        [Required]
        public int NumberOfCopies { get; set; } = 1;
    }
}
