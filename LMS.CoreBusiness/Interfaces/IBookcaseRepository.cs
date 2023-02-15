using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IBookcaseRepository : IBaseRepository<Bookcase>
    {
        Task<IEnumerable<Bookcase>> GetAsync();
    }
}
