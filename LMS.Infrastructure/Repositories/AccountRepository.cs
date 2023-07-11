using LMS.CoreBusiness.Entities.Accounts;
using LMS.CoreBusiness.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _role;

        public AccountRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> role)
        {
            _userManager = userManager;
            _role = role;
        }

        public async Task<IEnumerable<Roles>> GetRolesAsync()
        {
            return await _role.Roles
                        .Select(rl => new Roles
                        {
                            Id = rl.Id,
                            Name = rl.Name
                        })
                        .ToListAsync();
        }

        public async Task<bool> Register(Account account)
        {
            var userExists = await _userManager.FindByEmailAsync(account.Email);
            if (userExists is not null)
                return false;

            IdentityUser user = new()
            {
                UserName = account.Username,
                Email = account.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                NormalizedEmail = account.Email.ToUpper(),
                NormalizedUserName = account.Username.ToUpper()
            };
            var result = await _userManager.CreateAsync(user, account.Password);

            if (!result.Succeeded)
                return false;
            
            var response = await _userManager.AddToRoleAsync(user, account.Role);
            return response.Succeeded;
        }
    }
}
