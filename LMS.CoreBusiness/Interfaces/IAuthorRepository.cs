using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IAuthorRepository : IBaseRepository<Author>
    {
        Task<IEnumerable<Author>> GetAsync();
        Task<Author> GetByNameAsync(string name);
        Task<Author> GetByNationalityAsync(string nationality);
    }
}
