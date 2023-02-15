using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface ILibrarianRepository : IBaseRepository<Librarian>
    {
        Task<IEnumerable<Librarian>> GetAsync();
        Task<Librarian> GetByNameAsync(string name);
    }
}
