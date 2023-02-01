using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAsync();
        Task<Author> GetByIdAsync(int id);
        Task<Author> GetByNameAsync(string name);
        Task<Author> GetByNationalityAsync(string nationality);

        Task<Author> AddAsync(Author author);
        Task<Author> UpdateAsync(Author author);
        Task<bool> DeleteAsync(Author author);
        
    }
}
