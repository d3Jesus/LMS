using Azure;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.ViewModels;
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

        public async Task<Book> CreateAsync(AddBookViewModel book)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    DateTime date = DateTime.Now;
                    Book newBook = new()
                    {
                        Title = book.Title,
                        Description = book.Description,
                        Edition = book.Edition,
                        ISBN = book.ISBN,
                        CategoryId = book.CategoryId,
                        ImageUrl = book.ImageUrl,
                        Price = book.Price
                    };
                    _context.Books.Add(newBook);
                    await _context.SaveChangesAsync();

                    #region Authorship
                    if (book is not null)
                    {
                        foreach (int id in book.Authors)
                        {
                            Authorship authorship = new()
                            {
                                BookId = newBook.Id,
                                AuthorId = id
                            };
                            _context.Authorships.Add(authorship);
                            await _context.SaveChangesAsync();
                        }
                    }
                    #endregion

                    transaction.Commit();

                    return newBook;

                } catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        //public async Task<GetBookViewModel> UpdateAsync(GetBookViewModel book)
        //{
        //    _context.Entry(book).State = EntityState.Detached;
        //    _context.Books.Update(book);
        //    await _context.SaveChangesAsync();

        //    return book;
        //}

        //public async Task<bool> DeleteAsync(int id)
        //{
        //    Book book = await GetByAsync(id);
        //    _context.Entry(book).State = EntityState.Detached;
        //    _context.Books.Remove(book);
        //    await _context.SaveChangesAsync();

        //    return true;
        //}

        //public async Task<GetBookViewModel> GetByAsync(int id)
        //{
        //    return await _context.Books.FindAsync(id);
        //}

        //public async Task<IEnumerable<GetBookViewModel>> GetAllAsync()
        //{
        //    return await _context.Books.ToListAsync();
        //}

        //public async Task<IEnumerable<GetBookViewModel>> GetAllByAsync(string title)
        //{
        //    return await _context.Books.Where(b => b.Title.Equals(title,StringComparison.OrdinalIgnoreCase)).ToListAsync();
        //}

        //public async Task<IEnumerable<Book>> GetAllByAsync(int category)
        //{
        //    return await _context.Books.Where(b => b.CategoryId == category).ToListAsync();
        //}    
        
    }
}
