using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<Book> GetByAsync(int id);
        Task<IEnumerable<Book>> GetAllByAsync(int categoryId);
    }
}
