namespace LMS.CoreBusiness.Entities
{
    public class Stock : BaseEntity
    {
        public int NumberOfCopies { get; set; }
        public int BookId { get; set; }
    }
}
