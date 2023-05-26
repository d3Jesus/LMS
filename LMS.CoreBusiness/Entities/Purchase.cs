using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.CoreBusiness.Entities
{
    public class Purchase
    {
        private int _id;
        private int _librarianId;
        private DateTime _datePurchased;
        private decimal _totalpayed;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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

        public DateTime DatePurchased
        {
            get { return _datePurchased; }
            private set { _datePurchased = DateTime.Now; }
        }

        public decimal TotalPayed
        {
            get { return _totalpayed; }
            set { _totalpayed = value; }
        }

        public virtual List<Librarian> Librarians { get; set; }
    }
}
