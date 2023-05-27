namespace LMS.CoreBusiness.ViewModels
{
    public class AddBookViewModel
    {
        private string _title;
        private string _description;
        private int _edition;
        private string _isbn;
        private int _categoryId;
        private string _imageUrl;
        private DateTime _dateCreated;
        private decimal _price;
        private List<int> _authors;

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
            private set { _dateCreated = DateTime.Now; }
        }

        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public List<int> Authors
        {
            get { return _authors; }
            set { _authors = value; }
        }
    }
        
}
