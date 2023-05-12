using LMS.Application.ViewModels.Reservation;
using LMS.Application.ViewModels;

namespace LMS.Application.Interfaces
{
    public interface IReservationService
    {
        Task<ServiceResponse<GetReservationDto>> CreateAsync(AddReservationDto reservation);
        Task<ServiceResponse<GetReservationDto>> UpdateAsync(GetReservationDto reservation);
    }
}
