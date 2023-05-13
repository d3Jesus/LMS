namespace LMS.Application.ViewModels.Reservation
{
    public record GetReservationDto (int id, int bookId, int memberId, DateTime reservationDate, string reservationStatus);
}
