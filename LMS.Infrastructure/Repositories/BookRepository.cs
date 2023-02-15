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

        public async Task<Book> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task<bool> DeleteAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Detached;
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task<Book> GetByTitleAsync(string title)
        {
            return await _context.Books.Where(b => b.Title.Contains(title)).FirstOrDefaultAsync();
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            _context.Entry(book).State = EntityState.Detached;
            _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return book;
        }
    }
}
