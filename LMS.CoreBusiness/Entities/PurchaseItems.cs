
namespace LMS.CoreBusiness.Entities;

public class PurchaseItems
{
    private int _purchaseId;
    private int _bookId;
    private int _numberOfCopies;
    private decimal _unitPrice;
    private decimal _grossPrice;

    public int PurchaseId
    {
        get { return _purchaseId; }
        set { _purchaseId = value; }
    }
    public int BookId
    {
        get { return _bookId; }
        set { _bookId = value; }
    }

    public int NumberOfCopies
    {
        get { return _numberOfCopies; }
        set { _numberOfCopies = value; }
    }

    public decimal UnitPrice
    {
        get { return _unitPrice; }
        set { _unitPrice = value; }
    }

    public decimal GrossPrice
    {
        get { return _grossPrice; }
        set { _grossPrice = value; }
    }
    
    public Book Book { get; set; }
    public Purchase Purchase { get; set; }
}
