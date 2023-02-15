using LMS.Application.ViewModels.Reservation;
using LMS.Application.ViewModels;

namespace LMS.Application.Interfaces
{
    public interface IReservationService
    {
        Task<ServiceResponse<IEnumerable<GetReservationViewModel>>> GetAsync();
        Task<ServiceResponse<GetReservationViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetReservationViewModel>> AddAsync(AddReservationViewModel author);
        Task<ServiceResponse<GetReservationViewModel>> UpdateAsync(GetReservationViewModel author);
        Task<ServiceResponse<bool>> DeleteAsync(GetReservationViewModel author);
    }
}
