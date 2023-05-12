using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Detached;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Book book = await GetByAsync(id);
            _context.Entry(book).State = EntityState.Detached;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Book> GetByAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAsync(string title)
        {
            return await _context.Books.Where(b => b.Title.Equals(title,StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAsync(int category)
        {
            return await _context.Books.Where(b => b.CategoryId == category).ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }        
        
    }
}
