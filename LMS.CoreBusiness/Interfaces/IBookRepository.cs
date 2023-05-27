using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.ViewModels;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> CreateAsync(AddBookViewModel book);
        Task<GetBookViewModel> UpdateAsync(UpdateBookViewModel book);
        Task<bool> DeleteAsync(int id);
        Task<GetBookViewModel> GetByAsync(int id);
        Task<IEnumerable<GetBookViewModel>> GetAllAsync();
        Task<IEnumerable<GetBookViewModel>> GetAllByAsync(string title);
        Task<IEnumerable<Book>> GetAllByAsync(int category);
    }
}
