using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Stock
{
    public class AddStockDto
    {
        [Required]
        public int NumberOfCopies { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
