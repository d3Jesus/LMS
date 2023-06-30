namespace LMS.CoreBusiness.Entities;

public class Purchase
{
    private int _id;
    private int _librarianId;
    private string _customerName;
    private DateTime _datePurchased;
    private decimal _totalPayed;
    public virtual List<PurchaseItems> Items { get; set; } = new();

    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    public int LibrarianId
    {
        get { return _librarianId; }
        set { _librarianId = value; }
    }

    public string CustomerName
    {
        get { return _customerName; }
        set { _customerName = value; }
    }

    public DateTime DatePurchased
    {
        get { return _datePurchased; }
        private init { _datePurchased = DateTime.Now; }
    }

    public decimal TotalPayed
    {
        get { return _totalPayed; }
        set { _totalPayed = value; }
    }

    public virtual List<Librarian> Librarians { get; set; }
}
