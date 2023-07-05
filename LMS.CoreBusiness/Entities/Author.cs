namespace LMS.CoreBusiness.Entities
{
    public class Author : Person
    {
        private string _nationality;

        public string Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }
        
        public virtual List<Authorship> Authorships { get; set; }
        public virtual List<Book> Books { get; set; }
    }
}
