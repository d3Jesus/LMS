using LMS.CoreBusiness.Entities.Accounts;
using LMS.CoreBusiness.Requests.Account;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Roles>> GetRolesAsync();
        Task<bool> Register(UserRegistrationRequest account);
        Task<string> Login(UserLoginRequest account);
    }
}
