using LMS.CoreBusiness.Entities.Accounts;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LMS.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _role;
        private readonly UsersDbContext _context;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> role, 
            UsersDbContext context, 
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _role = role;
            _context = context;
            _signInManager = signInManager;
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

        public async Task<bool> Login(UserLogin account)
        {
            var result = await _signInManager.PasswordSignInAsync(account.Email, account.Password, false, true);

            if (result.Succeeded)
            {
                // create JWT
             
                Log.Information($"User {account.Email} logged in.");
                return true;
            }

            if (result.IsLockedOut)
                Log.Information($"User account {account.Email} was locked out.");
            
            if (result.IsNotAllowed)
                Log.Information($"User account {account.Email} not allowed.");

            return false;
        }

        public async Task<bool> Register(UserRegistration account)
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
