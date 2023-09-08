using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LMS.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly int _booksToTake = 100;

        public BookRepository(ApplicationDbContext context) => _context = context;

        public async Task<Book> CreateAsync(Book book)
        {
            try
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();

                return book;

            } 
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                return null;
            }
        }

        public async Task<Book> UpdateAsync(Book book)
        {
            try
            {
                Book existingBook = await GetByAsync(book.Id);
                if (existingBook is null) return new Book();

                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.Edition = book.Edition;
                existingBook.ISBN = book.ISBN;
                existingBook.CategoryId = book.CategoryId;
                existingBook.ImageUrl = book.ImageUrl;
                existingBook.Price = book.Price;
                existingBook.Status = book.Status;
                existingBook.CopiesAvailable = book.CopiesAvailable;

                _context.Entry(existingBook).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return existingBook;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
                return new Book();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Book book = await GetByAsync(id);
                if (book is null) return false;
                
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);

                return false;
            }
            
        }

        public async Task<Book> GetByAsync(int id)
        {
            return await _context.Books
                        .Where(b => b.Id == id)
                        .Include(b => b.Category)
                        .AsNoTrackingWithIdentityResolution()
                        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetAsync()
        {
            return await _context.Books
                        .Include(b => b.Category)
                        .Skip(0)
                        .Take(_booksToTake)
                        .OrderBy(b => b.Title)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAsync(string title)
        {
            return await _context.Books
                        .Where(b => b.Title.Contains(title))
                        .Include(b => b.Category)
                        .Skip(0)
                        .Take(_booksToTake)
                        .OrderBy(b => b.Title)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAsync(int category)
        {
            return await _context.Books
                        .Where(b => b.CategoryId == category)
                        .Include(b => b.Category)
                        .Skip(0)
                        .Take(_booksToTake)
                        .OrderBy(b => b.Title)
                        .ToListAsync();
        }

    }
}
