﻿using LMS.CoreBusiness.Entities.Accounts;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;

namespace LMS.Infrastructure.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _role;
        private readonly UsersDbContext _context;

        public AccountRepository(
            UserManager<IdentityUser> userManager,
            RoleManager<IdentityRole> role, 
            UsersDbContext context)
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

        public async Task<string> Login(UserLogin account)
        {
            string tokenString = string.Empty;
            bool result = await AuthenticateUser(account.Email, account.Password);

            if (result)
            {
                // create JWT
                var user = await _userManager.FindByEmailAsync(account.Email);
                var userRole = (await _userManager.GetRolesAsync(user)).FirstOrDefault();
                GenerateToken(out tokenString, user, userRole);

                Log.Information($"User {account.Email} logged in.");
            }

            return tokenString;
        }

        private async Task<bool> AuthenticateUser(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null) return false;

            var isPasswordValid = await _userManager.CheckPasswordAsync(user, password);
            if (!isPasswordValid) return false;

            return true;
        }

        private void GenerateToken(out string tokenString, IdentityUser user, string role)
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("JWTAuthentication@123"));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                claims: CreateClaims(user, role),
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
            tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
        }

        private List<Claim> CreateClaims(IdentityUser user, string role)
        {
            try
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
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