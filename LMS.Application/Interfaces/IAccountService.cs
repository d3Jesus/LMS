using LMS.Application.ViewModels;
using LMS.Application.ViewModels.UserAccount;

namespace LMS.Application.Interfaces
{
    public interface IAccountService
    {
        Task<ServiceResponse<IEnumerable<RolesDto>>> GetRoles();
        Task<ServiceResponse<bool>> Register(UserRegistrationDto model);
        Task<ServiceResponse<string>> Login(UserLoginDto model);
    }
}
