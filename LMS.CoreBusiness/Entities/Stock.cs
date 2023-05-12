namespace LMS.CoreBusiness.Entities
{
    public class Stock
    {
        private int _bookid;
        private int _copiesOwned;
        private int copiesAvailable;

        public int Book
        {
            get { return _bookid; }
            set { _bookid = value; }
        }
        public int NumberOfCopies
        {
            get { return _copiesOwned; }
            set { _copiesOwned = value; }
        }
        public int CopiesAvailable
        {
            get { return copiesAvailable; }
            set { copiesAvailable = value; }
        }
    }
}
