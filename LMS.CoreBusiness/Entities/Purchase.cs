namespace LMS.CoreBusiness.Entities;

public class Purchase
{
    // many-to-many relationship with Book
    public virtual IList<PurchaseItems> PurchaseItems { get; set; }
    public virtual List<Librarian> Librarians { get; set; }

    public int Id { get; set; }

    public int LibrarianId { get; set; }

    public string CustomerName { get; set; }

    public DateTime DatePurchased { get; set; } =DateTime.Now;

    public decimal TotalPayed { get; set; }

}
