namespace LMS.CoreBusiness.Entities
{
    public class Request : BaseEntity
    {
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public int NumberOfCopies { get; set; } = 1;
        public DateTime RequestDate { get; set; } = DateTime.Now;
        public bool WasReturned { get; set; } = false;
        public DateTime ReturnDate { get; set; } = DateTime.Now;
    }
}
