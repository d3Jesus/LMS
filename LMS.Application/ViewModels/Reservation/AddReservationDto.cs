using System.ComponentModel.DataAnnotations;

namespace LMS.Application.ViewModels.Reservation
{
    public class AddReservationDto
    {
        [Required]
        public int BookId { get; set; }
        [Required]
        public int ReaderId { get; set; }
        [Required]
        public string ReservationStatus { get; set; }
    }
}
