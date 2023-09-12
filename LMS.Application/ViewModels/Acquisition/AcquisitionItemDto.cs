using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Acquisition;

public class AcquisitionItemDto
{
    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public int BookId { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public int Quantity { get; set; } = 1;

    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public decimal PurchasePrice { get; set; } = 0;

    [Required(ErrorMessage = "Este campo é obrigatório.")]
    public decimal SalePrice { get; set; } = 0;
    
    public decimal GrossPrice { get; set; } = 0;
}
