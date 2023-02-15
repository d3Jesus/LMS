using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IRequestRepository : IBaseRepository<Request>
    {
        Task<IEnumerable<Request>> GetAsync();
    }
}
