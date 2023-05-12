using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class AuthorshipRepository :IAuthorshipRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorshipRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Authorship> CreateAsync(Authorship authorship)
        {
            _context.Authorships.Add(authorship);
            await _context.SaveChangesAsync();

            return authorship;
        }

        public async Task<bool> DeleteAsync(Authorship authorship)
        {
            _context.Entry(authorship).State = EntityState.Detached;
            _context.Authorships.Remove(authorship);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Authorship>> GetAsync()
        {
            return await _context.Authorships.ToListAsync();
        }

        public async Task<Authorship> GetByIdAsync(int id)
        {
            return await _context.Authorships.FindAsync(id);
        }

        public async Task<Authorship> UpdateAsync(Authorship authorship)
        {
            _context.Entry(authorship).State = EntityState.Detached;
            _context.Authorships.Update(authorship);
            await _context.SaveChangesAsync();

            return authorship;
        }
    }
}
