using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.CoreBusiness.Entities
{
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

    public decimal Price { get; set; }

    public string Status { get; set; }

    public int CopiesAvailable { get; set; }

        public int CopiesAvailable
        {
            get { return _copiesAvailable; }
            set { _copiesAvailable = value; }
        }

        public virtual List<Authorship> Authorships { get; set; }
        public virtual List<Category> Categories { get; set; }

        #region many-to-many relationship with Purchase
        public virtual IList<PurchaseItems> PurchaseItems { get; set; }
        // public virtual IList<Purchase> Purchases { get; set; } = new List<Purchase>();
        #endregion
    }
}