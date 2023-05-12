using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly ApplicationDbContext _context;

        public LibrarianRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Librarian> CreateAsync(Librarian librarian)
        {
            _context.Librarians.Add(librarian);
            await _context.SaveChangesAsync();

            return librarian;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var librarian = _context.Librarians.Find(id);
            _context.Librarians.Remove(librarian);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Librarian>> GetAsync()
        {
            return await _context.Librarians.ToListAsync();
        }

        public async Task<IEnumerable<Librarian>> GetAsync(bool wasDeleted)
        {
            return await _context.Librarians.Where(lb => lb.WasDeleted == wasDeleted).ToListAsync();
        }

        public async Task<Librarian> GetByAsync(int id)
        {
            return await _context.Librarians.Where(lb => lb.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Librarian>> GetByAsync(string name)
        {
            return await _context.Librarians
                .Where(l => l.FirstName.Contains(name) ||
                        l.LastName.Contains(name))
                .ToListAsync();
        }

        public async Task<Librarian> UpdateAsync(Librarian librarian)
        {
            _context.Entry(librarian).State = EntityState.Detached;
            _context.Librarians.Update(librarian);
            await _context.SaveChangesAsync();

            return librarian;
        }
    }
}
