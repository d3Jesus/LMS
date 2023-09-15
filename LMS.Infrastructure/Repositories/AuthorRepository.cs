using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using LMS.CoreBusiness.Responses.Book;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

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

        public async Task<PagedList<GetAuthorsResponse>> GetAsync(GetAuthorsRequest request)
        {
            IQueryable<GetAuthorsResponse> authorsQuery = _context.Authors
                                                           .Where(prc => prc.WasDeleted == request.WasDeleted)
                                                           .Include(prc => prc.Authorships)
                                                           .ThenInclude(authorship => authorship.Book)
                                                           .Select(x => new GetAuthorsResponse()
                                                           {
                                                               Id = x.Id,
                                                               FirstName = x.FirstName,
                                                               LastName = x.LastName,
                                                               Nationality = x.Nationality,
                                                               Books = x.Authorships.Select(y => new GetBookResumeResponse
                                                               { 
                                                                   Id = y.Book.Id,
                                                                   Title = y.Book.Title,
                                                                   Description = y.Book.Description
                                                               }).ToList()
                                                           });

            authorsQuery = request.SortOrder.ToLower().Equals("desc") ?
                                authorsQuery.OrderByDescending(GetSortProperty(request.SortColumn)) :
                                authorsQuery.OrderBy(GetSortProperty(request.SortColumn));

            int totalCount = await authorsQuery.CountAsync();
            var authorsList = await authorsQuery
                                                .Skip((request.CurrentPage - 1) * request.PageSize)
                                                .Take(request.PageSize).ToListAsync();

            var authorsPaged = PagedList<GetAuthorsResponse>.CreateAsync(authorsList,
                                                                  request.CurrentPage,
                                                                  request.PageSize,
                                                                  totalCount);

            return authorsPaged;

        }

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

        private static Expression<Func<GetAuthorsResponse, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "first_name" => author => author.FirstName,
                "last_name" => author => author.LastName,
                "nationality" => author => author.Nationality,
                _ => author => author.Id
            };
        }
    }
}
