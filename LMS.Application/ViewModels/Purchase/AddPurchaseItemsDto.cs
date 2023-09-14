namespace LMS.Application.ViewModels.Purchase;

public class AddPurchaseItemsDto
{
    public int BookId { get; set; }

    public int NumberOfCopies { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal GrossPrice => UnitPrice * NumberOfCopies;
}