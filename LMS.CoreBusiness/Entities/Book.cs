
namespace LMS.CoreBusiness.Entities;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public int Edition { get; set; }

    public string ISBN { get; set; }

    public int CategoryId { get; set; }
    public virtual Category Category { get; set; }

    public string ImageUrl { get; set; }

    public DateTime DateCreated { get; set; }

    public virtual ICollection<Authorship> Authorships { get; set; }
    public virtual ICollection<PurchaseItems> PurchaseItems { get; set; }
}