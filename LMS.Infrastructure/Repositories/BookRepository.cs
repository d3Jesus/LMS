using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly int _booksToTake = 100;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book book, List<int> authors)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    _context.Books.Add(book);
                    _context.SaveChanges();

                    #region Authorship
                    if (book is not null)
                    {
                        foreach (int authorId in authors)
                        {
                            Authorship authorship = new()
                            {
                                BookId = book.Id,
                                AuthorId = authorId
                            };
                            _context.Authorships.Add(authorship);
                            await _context.SaveChangesAsync();
                        }
                    }
                    #endregion

                    transaction.Commit();

                    return book;

                } catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public async Task<Book> UpdateAsync(Book book, List<int> authors)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    var authorships = await GetAuthorshipByBookIdAsync(book.Id);

                    if (authorships is not null)
                    {
                        _context.Authorships.RemoveRange(authorships.ToArray());
                        _context.SaveChanges();
                        foreach (int authorId in authors)
                        {
                            _context.Authorships
                                .Add(
                                    new Authorship()
                                    {
                                        BookId = book.Id,
                                        AuthorId = authorId
                                    });
                            await _context.SaveChangesAsync();
                        }
                    }

                    Book existingBook = await GetByAsync(book.Id);
                    if(existingBook is not null)
                    {
                        existingBook.Title = book.Title;
                        existingBook.Description = book.Description;
                        existingBook.Edition = book.Edition;
                        existingBook.ISBN = book.ISBN;
                        existingBook.CategoryId = book.CategoryId;
                        existingBook.ImageUrl = book.ImageUrl;
                        existingBook.Price = book.Price;

                        _context.Books.Update(existingBook);
                        await _context.SaveChangesAsync();
                    }

                    transaction.Commit();

                    return existingBook;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                Book book = await GetByAsync(id);

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        public async Task<Book> GetByAsync(int id)
        {
            return await _context.Books
                        .Where(b => b.Id == id)
                        .Include(b => b.Category)
                        .Include(b => b.ListOfAuthors)
                        .AsNoTrackingWithIdentityResolution()
                        .FirstOrDefaultAsync();
        }

        private async Task<List<Authorship>> GetAuthorshipByBookIdAsync(int id)
        {
            return await _context.Authorships
                        .Where(auth => auth.BookId == id)
                        .AsNoTrackingWithIdentityResolution()
                        .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books
                        .Include(b => b.Category)
                        .Include(b => b.ListOfAuthors)
                        .Include(b => b.PurchaseItems)
                        .ThenInclude(b => b.Purchase)
                        .Skip(0)
                        .Take(_booksToTake)
                        .OrderBy(b => b.Title)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAsync(string title)
        {
            return await _context.Books
                        .Where(b => b.Title.Contains(title))
                        .Include(b => b.Category)
                        .Skip(0)
                        .Take(_booksToTake)
                        .ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAsync(int category)
        {
            return await _context.Books
                        .Where(b => b.CategoryId == category)
                        .Include(b => b.Category)
                        .Skip(0)
                        .Take(_booksToTake)
                        .ToListAsync();
        }

    }
}
