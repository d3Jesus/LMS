
namespace LMS.CoreBusiness.Entities;

public class PurchaseItems
{
    public int PurchaseId { get; set; }
    public int BookId { get; set; }

    public int NumberOfCopies { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal GrossPrice { get; set; }

    public Book Book { get; set; }
    public Purchase Purchase { get; set; }
}
