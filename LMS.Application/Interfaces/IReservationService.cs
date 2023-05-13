using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Reservation;

namespace LMS.Application.Interfaces
{
    public interface IReservationService
    {
        Task<ServiceResponse<GetReservationDto>> CreateAsync(AddReservationDto reservation);
        Task<ServiceResponse<GetReservationDto>> UpdateAsync(GetReservationDto reservation);
        Task<ServiceResponse<IEnumerable<GetReservationDto>>> GetAllAsync();
        Task<ServiceResponse<GetReservationDto>> GetByAsync(int id);
    }
}
