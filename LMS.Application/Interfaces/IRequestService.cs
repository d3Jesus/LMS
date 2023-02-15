using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Request;

namespace LMS.Application.Interfaces
{
    public interface IRequestService
    {
        Task<ServiceResponse<IEnumerable<GetRequestViewModel>>> GetAsync();
        Task<ServiceResponse<GetRequestViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetRequestViewModel>> AddAsync(AddRequestViewModel author);
        Task<ServiceResponse<GetRequestViewModel>> UpdateAsync(GetRequestViewModel author);
        Task<ServiceResponse<bool>> DeleteAsync(GetRequestViewModel author);
    }
}
