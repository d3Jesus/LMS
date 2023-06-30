namespace LMS.BlazorUI.Data.Models.ViewModels;

public class AddPurchaseItemViewModel
{
    public int BookId { get; set; }
    public string BookTitle { get; set; }
    public decimal BookPrice { get; set; }
    public int NumberOfCopies { get; set; } = 1;
    public decimal GrossPrice { get; set; }
}