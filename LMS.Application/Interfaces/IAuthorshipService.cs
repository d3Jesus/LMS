using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Authorship;

namespace LMS.Application.Interfaces
{
    public interface IAuthorshipService
    {
        Task<ServiceResponse<GetAuthorshipDto>> AddAsync(AddAuthorshipDto model);
        Task<ServiceResponse<GetAuthorshipDto>> UpdateAsync(GetAuthorshipDto model);
    }
}
