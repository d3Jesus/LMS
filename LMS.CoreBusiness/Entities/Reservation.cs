namespace LMS.CoreBusiness.Entities
{
    public class Reservation : BaseEntity
    {
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationStatus { get; set; }
    }
}
