using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LMS.Infrastructure.Repositories
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly ApplicationDbContext _context;

        public LibrarianRepository(ApplicationDbContext context) => _context = context;

        public async Task<Librarian> CreateAsync(Librarian librarian)
        {
            try
            {
                _context.Librarians.Add(librarian);
                await _context.SaveChangesAsync();

                return librarian;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);

                return null;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try 
            {
                var librarian = _context.Librarians.Find(id);
                _context.Librarians.Remove(librarian);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);

                return false;
            }
        }

        public async Task<IEnumerable<Librarian>> GetAsync() 
            => await _context.Librarians.ToListAsync();

        public async Task<IEnumerable<Librarian>> GetAsync(bool wasDeleted) 
            => await _context.Librarians.Where(lb => lb.WasDeleted == wasDeleted)
                                        .ToListAsync();

        public async Task<Librarian> GetAsync(int id) 
            => await _context.Librarians.Where(lb => lb.Id == id)
                                        .FirstOrDefaultAsync();

        public async Task<IEnumerable<Librarian>> GetAsync(string name)
            => await _context.Librarians.Where(l => l.FirstName.Contains(name) || l.LastName.Contains(name)).ToListAsync();

        public async Task<Librarian> UpdateAsync(Librarian librarian)
        {
            try
            {
                _context.Entry(librarian).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return librarian;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);

                return new Librarian();
            }

        }
    }
}
