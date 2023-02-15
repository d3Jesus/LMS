using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Authorship;

namespace LMS.Application.Interfaces
{
    public interface IAuthorshipService
    {
        Task<ServiceResponse<GetAuthorshipViewModel>> AddAsync(AddAuthorshipViewModel model);
        Task<ServiceResponse<GetAuthorshipViewModel>> UpdateAsync(GetAuthorshipViewModel model);
        Task<ServiceResponse<bool>> DeleteAsync(GetAuthorshipViewModel model);
    }
}
