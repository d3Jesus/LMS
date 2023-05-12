using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author> CreateAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingAuthor = _context.Authors.Where(auth => auth.Id == id).FirstOrDefault();

            _context.Authors.Remove(existingAuthor);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<IEnumerable<Author>> GetAsync(bool wasDeleted)
        {
            return await _context.Authors.Where(auth => auth.WasDeleted).ToListAsync();
        }

        public async Task<Author> GetByAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<IEnumerable<Author>> GetByAsync(string name)
        {
            return await _context.Authors.Where(c => c.FirstName == name || c.LastName == name).ToListAsync();
        }

        public async Task<Author> GetByNationalityAsync(string nationality)
        {
            return await _context.Authors.Where(c => c.Nationality == nationality).FirstOrDefaultAsync();
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();

            return author;
        }
    }
}
