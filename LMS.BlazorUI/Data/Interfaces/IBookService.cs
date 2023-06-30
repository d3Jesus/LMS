using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.Models.ViewModels;

namespace LMS.BlazorUI.Data.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<GetBookViewModel>> GetAllAsync();
        Task<Book> GetByAsync(int id);
        Task<List<GetBookViewModel>> GetByAsync(string title);
        Task<IEnumerable<GetBookViewModel>> GetAllByAsync(int categoryId);
        Task<ServiceResponse<Book>> CreateAsync(AddBookViewModel model);
        Task<ServiceResponse<Book>> UpdateAsync(AddBookViewModel model);
    }
}
