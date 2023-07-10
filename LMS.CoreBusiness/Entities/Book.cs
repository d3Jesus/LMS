using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.CoreBusiness.Entities
{
    public class Book
    {
        private int _id;
        private string _title;
        private string _description;
        private int _edition;
        private string _isbn;
        private int _categoryId;
        public virtual Category Category { get; set; }
        private string _imageUrl;
        private DateTime _dateCreated;
        private decimal _price;
        private string _status;
        private int _copiesAvailable;

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title 
        { 
            get { return _title; } 
            set { _title = value; } 
        }

        public string Description 
        { 
            get { return _description; } 
            set { _description = value; } 
        }

        public int Edition 
        {
            get { return _edition; } 
            set { _edition = value; } 
        }

        public string ISBN 
        {
            get { return _isbn; }
            set { _isbn = value; }
        }
        
        public int CategoryId 
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }

        public DateTime DateCreated
        {
            get { return _dateCreated; }
            set { _dateCreated = value; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public string Status
        {
            get { return _status; }
            set { _status = value; }
        }

        public int CopiesAvailable
        {
            get { return _copiesAvailable; }
            set { _copiesAvailable = value; }
        }

        public virtual List<Authorship> Authorships { get; set; }
        public virtual Author Author { get; set; }
        public virtual List<Author> ListOfAuthors { get; set; }
        public virtual List<int> Authors { get; set; }
        public virtual List<Category> Categories { get; set; }

        #region many-to-many relationship with Purchase
        public virtual IList<PurchaseItems> PurchaseItems { get; set; }
        // public virtual IList<Purchase> Purchases { get; set; } = new List<Purchase>();
        #endregion
    }
}