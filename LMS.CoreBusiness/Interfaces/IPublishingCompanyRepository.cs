using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IPublishingCompanyRepository : IBaseRepository<PublishingCompany>
    {
        Task<IEnumerable<PublishingCompany>> GetAsync();
        Task<PublishingCompany> GetByNameAsync(string name);
    }
}
