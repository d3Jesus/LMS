namespace LMS.CoreBusiness.Entities;

public class Purchase
{
    public int Id { get; set; }

    public int LibrarianId { get; set; }
    public virtual Librarian Librarians { get; set; }

    public DateTime DatePurchased { get; set; } = DateTime.Now;

    public decimal TotalPayed { get; set; }

    public virtual ICollection<PurchaseItems> PurchaseItems { get; set; }
}
