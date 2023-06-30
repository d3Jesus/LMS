using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IBookRepository
    {
        Task<bool> CreateAsync(Book book, List<int> authors);
        Task<bool> UpdateAsync(Book book, List<int> authors);
        Task<bool> DeleteAsync(int id);
        Task<Book> GetByAsync(int id);
        Task<IEnumerable<Book>> GetAllAsync();
        Task<IEnumerable<Book>> GetAllByAsync(string title);
        Task<IEnumerable<Book>> GetAllByAsync(int category);
    }
}
