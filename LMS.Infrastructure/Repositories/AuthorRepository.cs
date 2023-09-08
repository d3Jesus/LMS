using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LMS.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context) => _context = context;

        public async Task<Author> CreateAsync(Author author)
        {
            try
            {
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();

                return author;
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
                var existingAuthor = _context.Authors.Where(auth => auth.Id == id).FirstOrDefault();

                _context.Authors.Remove(existingAuthor);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);

                return false;
            }
        }

        public async Task<IEnumerable<Author>> GetAsync(bool wasDeleted) 
            => await _context.Authors.Where(auth => auth.WasDeleted == wasDeleted).ToListAsync();

        public async Task<Author> GetByAsync(int id) 
            => await _context.Authors.FindAsync(id);

        public async Task<IEnumerable<Author>> GetByAsync(string name)
            => await _context.Authors.Where(c => c.FirstName == name || c.LastName == name).ToListAsync();

        public async Task<Author> GetByNationalityAsync(string nationality)
            => await _context.Authors.Where(c => c.Nationality == nationality).FirstOrDefaultAsync();

        public async Task<Author> UpdateAsync(Author author)
        {
            try
            {
                _context.Authors.Update(author);
                await _context.SaveChangesAsync();

                return author;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);

                return null;
            }
            
        }
    }
}
