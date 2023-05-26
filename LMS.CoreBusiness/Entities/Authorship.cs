namespace LMS.CoreBusiness.Entities
{
    public class Authorship
    {
        private int _authorId;
        private int _bookId;

        public int AuthorId
        {
            get { return _authorId; }
            set { _authorId = value; }
        }
        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }

        public virtual List<Author> Authors { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
