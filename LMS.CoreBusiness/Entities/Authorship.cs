namespace LMS.CoreBusiness.Entities
{
    public class Authorship : BaseEntity
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
    }
}
