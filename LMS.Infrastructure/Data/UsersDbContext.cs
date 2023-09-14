using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LMS.CoreBusiness.Entities.Accounts;

namespace LMS.Infrastructure.Data
{
    public class UsersDbContext : IdentityDbContext<AspNetUsers>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options) : base(options) { }
    }
}
