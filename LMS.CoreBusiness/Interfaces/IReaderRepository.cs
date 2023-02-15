using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IReaderRepository : IBaseRepository<Reader>
    {
        Task<IEnumerable<Reader>> GetAsync();
        Task<Reader> GetByNameAsync(string name);
    }
}
