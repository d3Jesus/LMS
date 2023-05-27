using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Book;

namespace LMS.Application.Interfaces
{
    public interface IBookService
    {
        Task<ServiceResponse<GetBookDto>> CreateAsync(AddBookDto model);
        Task<ServiceResponse<GetBookDto>> UpdateAsync(UpdateBookDto model);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<GetAllBooksDto>> GetByIdAsync(int id);
        Task<ServiceResponse<IEnumerable<GetAllBooksDto>>> GetAllAsync();
        Task<ServiceResponse<IEnumerable<GetAllBooksDto>>> GetAllByAsync(string title);
        Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAllByAsync(int category);
    }
}
