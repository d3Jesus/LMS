using LMS.Application.ViewModels.PublishingCompany;
using LMS.Application.ViewModels;

namespace LMS.Application.Interfaces
{
    public interface IPublishingCompanyService
    {
        Task<ServiceResponse<IEnumerable<GetPublishingCompanyViewModel>>> GetAsync();
        Task<ServiceResponse<GetPublishingCompanyViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetPublishingCompanyViewModel>> GetByNameAsync(string name);
        Task<ServiceResponse<GetPublishingCompanyViewModel>> AddAsync(AddPublishingCompanyViewModel author);
        Task<ServiceResponse<GetPublishingCompanyViewModel>> UpdateAsync(GetPublishingCompanyViewModel author);
        Task<ServiceResponse<bool>> DeleteAsync(GetPublishingCompanyViewModel author);
    }
}
