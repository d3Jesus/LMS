namespace LMS.Application.ViewModels.Reservation
{
    public class GetReservationDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int ReaderId { get; set; }
        public DateTime ReservationDate { get; set; }
        public string ReservationStatus { get; set; }
    }
}
