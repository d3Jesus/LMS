using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Book;

namespace LMS.Application.Interfaces
{
    public interface IBookService
    {
        Task<ServiceResponse<IEnumerable<GetBookViewModel>>> GetAsync();
        Task<ServiceResponse<GetBookViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetBookViewModel>> GetByTitleAsync(string title);
        Task<ServiceResponse<GetBookViewModel>> AddAsync(AddBookViewModel model);
        Task<ServiceResponse<GetBookViewModel>> UpdateAsync(GetBookViewModel model);
        Task<ServiceResponse<bool>> DeleteAsync(GetBookViewModel model);
    }
}
