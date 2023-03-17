using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Bookcase;

namespace LMS.Application.Interfaces
{
    public interface IBookcaseService
    {
        Task<ServiceResponse<IEnumerable<GetBookcaseViewModel>>> GetAsync();
        Task<ServiceResponse<GetBookcaseViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetBookcaseViewModel>> AddAsync(AddBookcaseViewModel model);
        Task<ServiceResponse<GetBookcaseViewModel>> UpdateAsync(GetBookcaseViewModel model);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
