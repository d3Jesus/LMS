using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.ViewModels;

namespace LMS.Application.Interfaces
{
    public interface IBookService
    {
        Task<ServiceResponse<GetBookDto>> CreateAsync(AddBookDto model);
        //Task<ServiceResponse<GetBookDto>> UpdateAsync(GetBookDto model);
        //Task<ServiceResponse<bool>> DeleteAsync(int id);
        //Task<ServiceResponse<GetBookDto>> GetByIdAsync(int id);
        //Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAllAsync();
        //Task<ServiceResponse<GetBookDto>> GetAllByAsync(string title);
        //Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAllByAsync(int category);
    }
}
