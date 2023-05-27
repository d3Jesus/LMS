using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.ViewModels;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                    Book newBook = new()
                    {
                        Title = book.Title,
                        Description = book.Description,
                        Edition = book.Edition,
                        ISBN = book.ISBN,
                        CategoryId = book.CategoryId,
                        ImageUrl = book.ImageUrl,
                        DateCreated = DateTime.Now,
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

        public async Task<GetBookViewModel> UpdateAsync(UpdateBookViewModel book)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {

                    Book existingBook = await GetBookByAsync(book.Id);
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

                        var authorships = await GetAuthorshipByBookIdAsync(book.Id);
                        if(authorships is not null)
                            foreach (int authorId in book.Authors)
                            {
                                var authorship = authorships.Where(auth => auth.BookId == book.Id && auth.AuthorId == authorId).FirstOrDefault();

                                if(authorship is null)
                                {
                                    _context.Authorships.Add(authorship);
                                    await _context.SaveChangesAsync();
                                }
                                else
                                    authorships.Remove(authorship);
                            }

                        _context.Authorships.RemoveRange(authorships);
                        await _context.SaveChangesAsync();
                    }

                    transaction.Commit();

                    var updatedBook = await GetByAsync(book.Id);

                    return updatedBook;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return null;
                }
            }
            //_context.Entry(book).State = EntityState.Detached;
            //_context.Books.Update(book);
            //await _context.SaveChangesAsync();

            //return book;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using(var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Book book = await GetBookByAsync(id);
                    if (book is not null)
                    {
                        #region Authorship
                        var authorships = await GetAuthorshipByBookIdAsync(id);
                        if (authorships is not null)
                        {
                            foreach (var authorship in authorships)
                            {
                                _context.Authorships.Remove(authorship);
                                await _context.SaveChangesAsync();
                            }
                        }
                        #endregion
                    }

                    _context.Books.Remove(book);
                    await _context.SaveChangesAsync();


                    transaction.Commit();

                    return true;

                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    return false;
                }
            }
            //_context.Entry(book).State = EntityState.Detached;
            //_context.Books.Remove(book);
            //await _context.SaveChangesAsync();

            //return true;
        }

        public async Task<GetBookViewModel> GetByAsync(int id)
        {
            return await _context.GetBookViewModels.FindAsync(id);
        }

        private async Task<Book> GetBookByAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        private async Task<List<Authorship>> GetAuthorshipByBookIdAsync(int id)
        {
            return await _context.Authorships.Where(auth => auth.BookId == id).ToListAsync();
        }

        public async Task<IEnumerable<GetBookViewModel>> GetAllAsync()
        {
            return await _context.GetBookViewModels.ToListAsync();
        }

        public async Task<IEnumerable<GetBookViewModel>> GetAllByAsync(string title)
        {
            return await _context.GetBookViewModels.Where(b => b.title.Contains(title)).ToListAsync();
        }

        public async Task<IEnumerable<Book>> GetAllByAsync(int category)
        {
            return await _context.Books.Where(b => b.CategoryId == category).ToListAsync();
        }

    }
}
