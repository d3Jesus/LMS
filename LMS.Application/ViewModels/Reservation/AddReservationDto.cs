namespace LMS.Application.ViewModels.Reservation
{
    public record AddReservationDto(int bookId, int memberId, DateTime reservationDate, string reservationStatus);
}
