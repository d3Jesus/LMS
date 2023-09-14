using LMS.CoreBusiness.Entities.Accounts;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests.Account;
using LMS.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LMS.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AspNetUsers> _userManager;
        private readonly RoleManager<IdentityRole> _role;
        private readonly UsersDbContext _context;
        private readonly IConfiguration _configuration;

        public AccountRepository(
            UserManager<AspNetUsers> userManager,
            RoleManager<IdentityRole> role,
            UsersDbContext context,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _role = role;
            _context = context;
            _configuration = configuration;
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

        public async Task<string> Login(UserLoginRequest account)
        {
            bool result = await AuthenticateUser(account.Email, account.Password);

            if (result)
            {
                var user = _context.Users.Where(x => x.Email.Equals(account.Email)).Include(x => x.Librarian).FirstOrDefault();

                var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                GenerateToken(out string tokenString, user, userRole);

                Log.Information($"User {account.Email} logged in.");

                return tokenString;
            }

            return "Invalid credentials.";
        }

        private async Task<bool> AuthenticateUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid) return false;

            return true;
        }

        private void GenerateToken(out string tokenString, AspNetUsers user, string role)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtKeys:Secret").Value));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration.GetSection("JwtKeys:Issuer").Value,
                audience: _configuration.GetSection("JwtKeys:Audience").Value,
                claims: CreateClaims(user, role),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signinCredentials
            );
            tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        private static List<Claim> CreateClaims(AspNetUsers user, string role)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.LibrarianId.ToString()),
                    new Claim(ClaimTypes.Name, string.Concat(user.Librarian.FirstName, " ", user.Librarian.LastName)),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, role)
                };
                return claims;
            }
            catch (Exception exception)
            {
                Log.Error(exception, exception.Message, exception.InnerException);
                return Enumerable.Empty<Claim>().ToList();
            }
        }

        public async Task<bool> Register(UserRegistrationRequest account)
        {
            using var transaction = _context.Database.BeginTransaction();
            
            var userExists = await _userManager.FindByEmailAsync(account.Email);
            if (userExists is not null)
                return false;

            AspNetUsers user = new()
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
            if (response.Succeeded)
            {
                await transaction.CommitAsync();
                return response.Succeeded;
            }

            await transaction.RollbackAsync();
            return response.Succeeded;
        }
    }
}
