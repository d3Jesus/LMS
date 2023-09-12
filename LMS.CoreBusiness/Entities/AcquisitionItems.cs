
namespace LMS.CoreBusiness.Entities;

public class AcquisitionItems
{
    public int Id { get; set; }

    public string AcquisitionId { get; set; }
    public virtual Acquisition Acquisition { get; set; }

    public int BookId { get; set; }
    public virtual Book Book { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal PurchasePrice { get; set; }
    
    public decimal SalePrice { get; set; }
    
    public decimal GrossPrice { get; set; }
}
