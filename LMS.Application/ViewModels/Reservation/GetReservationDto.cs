namespace LMS.Application.ViewModels.Reservation
{
    public record GetReservationDto (int reservationId, string bookTitle, string memberName, DateTime reservationDate, string reservationStatus);
}
