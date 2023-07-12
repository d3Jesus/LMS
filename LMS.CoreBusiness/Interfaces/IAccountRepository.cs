using LMS.CoreBusiness.Entities.Accounts;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Roles>> GetRolesAsync();
        Task<bool> Register(UserRegistration account);
        Task<bool> Login(UserLogin account);
    }
}
