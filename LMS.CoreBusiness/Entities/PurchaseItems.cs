
namespace LMS.CoreBusiness.Entities;

public class PurchaseItems
{
    public int Id { get; set; }

    public int PurchaseId { get; set; }
    public virtual Purchase Purchase { get; set; }

    public int BookId { get; set; }
    public virtual Book Book { get; set; }

    public int NumberOfCopies { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal GrossPrice { get; set; }
}
