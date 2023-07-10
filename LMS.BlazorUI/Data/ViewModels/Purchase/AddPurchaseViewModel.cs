namespace LMS.BlazorUI.Data.ViewModels.Purchase;

public class AddPurchaseViewModel
{
    public string CustomerName { get; set; }
    public decimal TotalPayed { get; set; }
    public List<AddPurchaseItemsViewModel> Items { get; set; }
}
