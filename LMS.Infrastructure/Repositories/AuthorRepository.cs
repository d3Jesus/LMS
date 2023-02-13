using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace LMS.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _context;

        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Author> AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<bool> DeleteAsync(Author author)
        {
		var existingAuthor = _context.Authors.Where(auth => auth.Id == author.Id).FirstOrDefault();
		if (existingAuthor is null)
			throw new Exception($"Author with id {author.Id} not found.");

		_context.Entry(existingAuthor).State = EntityState.Detached;
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Author>> GetAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> GetByIdAsync(int id)
        {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
            return id is < 1 ? throw new ArgumentNullException("Author Id can't be 0") : await _context.Authors.FindAsync(id);
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
        }

        public async Task<Author> GetByNameAsync(string name)
        {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
            if (name is null) throw new ArgumentNullException("Author name can't be null");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly

            return await _context.Authors.Where(c => c.FirstName == name || c.LastName == name).FirstOrDefaultAsync();
        }

        public async Task<Author> GetByNationalityAsync(string nationality)
        {
#pragma warning disable CA2208 // Instantiate argument exceptions correctly
            if (nationality is null) throw new ArgumentNullException("Author nationality can't be null");
#pragma warning restore CA2208 // Instantiate argument exceptions correctly
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
