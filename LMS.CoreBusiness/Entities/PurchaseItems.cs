using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.CoreBusiness.Entities
{
    public class PurchaseItems
    {
        private int _id;
        private int _purchasedId;
        private int _bookId;
        private int _numberOfCopies;
        private decimal _basePrice;
        private decimal _purchasedPrice;
        private string _status;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public decimal BasePrice
        {
            get { return _basePrice; }
            set { _basePrice = value; }
        }

        public decimal PurchasedPrice
        {
            get { return _purchasedPrice; }
            set { _purchasedPrice = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public virtual List<Book> Books { get; set; }
        public virtual List<Purchase> Purchases { get; set; }
    }
}
