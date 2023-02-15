using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Stock
{
    public class AddStockViewModel
    {
        [Required]
        public int NumberOfCopies { get; set; }
        [Required]
        public int BookId { get; set; }
    }
}
