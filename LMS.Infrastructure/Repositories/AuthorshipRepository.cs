using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Net.Security;

namespace LMS.Infrastructure.Repositories;

public class AuthorshipRepository : IAuthorshipRepository
{
    private readonly ApplicationDbContext _context;

    public AuthorshipRepository(ApplicationDbContext context) => _context = context;

    public async Task<bool> CreateOrUpdateAsync(int bookId, List<int> bookAuthors)
    {
        try
        {
            List<Authorship> authorships = await GetAllByAsync(bookId);
            
            foreach (var authorId in bookAuthors)
            {
                var authorship = authorships.Where(x => x.BookId == bookId &&  x.AuthorId == authorId).FirstOrDefault();
                
                if (authorship is null)
                    Create(bookId, authorId);
                else
                    Update(authorId, authorship);

                authorships.Remove(authorship);
            }
            
            _context.Authorships.RemoveRange(authorships);
            _context.SaveChanges();

            return true;
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.Message);

            return false;
        }
    }

    private void Update(int authorId, Authorship authorship)
    {
        authorship.AuthorId = authorId;

        _context.Entry(authorship).State = EntityState.Modified;
    }

    private void Create(int bookId, int authorId)
    {
        Authorship authorship = new()
        {
            BookId = bookId,
            AuthorId = authorId
        };
        _context.Authorships.Add(authorship);
    }

    private async Task<List<Authorship>> GetAllByAsync(int bookId) 
        => await _context.Authorships
                    .Where(auth => auth.BookId == bookId)
                    .AsNoTracking()
                    .ToListAsync();

    private async Task<Authorship> GetByAsync(int bookId) 
        => await _context.Authorships
                    .Where(auth => auth.BookId == bookId)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
}
