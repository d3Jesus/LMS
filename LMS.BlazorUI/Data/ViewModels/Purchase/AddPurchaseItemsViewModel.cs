namespace LMS.BlazorUI.Data.ViewModels.Purchase;

public class AddPurchaseItemsViewModel
{
    public int BookId { get; set; }
    public virtual string BookTitle { get; set; }
    public decimal UnitPrice { get; set; }
    public int NumberOfCopies { get; set; }
    public decimal GrossPrice { get; set; }
}