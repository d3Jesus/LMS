using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses.Book;
using LMS.CoreBusiness.Responses;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace LMS.Infrastructure.Repositories
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly ApplicationDbContext _context;

        public LibrarianRepository(ApplicationDbContext context) => _context = context;

        public async Task<Librarian> CreateAsync(Librarian librarian)
        {
            try
            {
                _context.Librarians.Add(librarian);
                await _context.SaveChangesAsync();

                return librarian;
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
                var librarian = _context.Librarians.Find(id);
                _context.Librarians.Remove(librarian);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);

                return false;
            }
        }

        public async Task<PagedList<Librarian>> GetAsync(ResourceRequest request)
        {
            IQueryable<Librarian> librariansQuery = _context.Librarians
                                                           .Where(prc => prc.WasDeleted == request.WasDeleted &&
                                                                (prc.FirstName.Contains(request.SearchTerm) || prc.LastName.Contains(request.SearchTerm) ||
                                                                prc.Address.Contains(request.SearchTerm) || prc.PhoneNumber.Contains(request.SearchTerm) || 
                                                                prc.Email.Contains(request.SearchTerm)));

            librariansQuery = request.SortOrder.ToLower().Equals("desc") ?
                                librariansQuery.OrderByDescending(GetSortProperty(request.SortColumn)) :
                                librariansQuery.OrderBy(GetSortProperty(request.SortColumn));

            int totalCount = await librariansQuery.CountAsync();
            var librariansList = await librariansQuery
                                                .Skip((request.CurrentPage - 1) * request.PageSize)
                                                .Take(request.PageSize).ToListAsync();

            var librariansPaged = PagedList<Librarian>.CreateAsync(librariansList,
                                                                  request.CurrentPage,
                                                                  request.PageSize,
                                                                  totalCount);

            return librariansPaged;
        }

        public async Task<Librarian> GetAsync(int id) 
            => await _context.Librarians.Where(lb => lb.Id == id)
                                        .FirstOrDefaultAsync();

        public async Task<Librarian> UpdateAsync(Librarian librarian)
        {
            try
            {
                _context.Entry(librarian).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return librarian;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);

                return new Librarian();
            }

        }
        private static Expression<Func<Librarian, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "first_name" => librarian => librarian.FirstName,
                "last_name" => librarian => librarian.LastName,
                "phone" => librarian => librarian.PhoneNumber,
                "address" => librarian => librarian.Address,
                "email" => librarian => librarian.Email,
                _ => librarian => librarian.Id
            };
        }
    }
}
