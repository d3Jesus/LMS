
namespace LMS.BlazorUI.Data.Models;

public class PurchaseItems
{
    private int _id;
    private int _purchasedId;
    public virtual Purchase Purchase { get; set; }
    private int _bookId;
    public virtual Book Book { get; set; }
    private int _numberOfCopies;
    private decimal _unitPrice;
    private decimal _grossPrice;
    private string _status;

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public int BookId
    {
        get { return _bookId; }
        set { _bookId = value; }
    }

    public int PurchasedId
    {
        get { return _purchasedId; }
        set { _purchasedId = value; }
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

    public string Status
    {
        get { return _status; }
        set { _status = value; }
    }
}
