namespace LMS.CoreBusiness.Entities
{
    public class Author : Person
    {
        public string Nationality { get; set; }
        
        public virtual ICollection<Authorship> Authorships { get; set; }
    }
}
