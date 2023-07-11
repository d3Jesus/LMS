using LMS.CoreBusiness.Entities.Accounts;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _role;
        private readonly UsersDbContext _context;

        public AccountRepository(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> role, UsersDbContext context)
        {
            _userManager = userManager;
            _role = role;
            _context = context;
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
            using (var transaction = _context.Database.BeginTransaction())
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
                if(response.Succeeded)
                {
                    await transaction.CommitAsync();
                    return response.Succeeded;
                }

                await transaction.RollbackAsync();
                return response.Succeeded;
            }
        }
    }
}
