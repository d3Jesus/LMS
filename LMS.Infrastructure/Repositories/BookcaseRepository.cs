using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class BookcaseRepository : IBookcaseRepository
    {
        private readonly ApplicationDbContext _context;

        public BookcaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Bookcase> AddAsync(Bookcase bookcase)
        {
            _context.Bookcases.Add(bookcase);
            await _context.SaveChangesAsync();

            return bookcase;
        }

        public async Task<bool> DeleteAsync(Bookcase bookcase)
        {
            _context.Entry(bookcase).State = EntityState.Detached;
            _context.Bookcases.Remove(bookcase);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Bookcase>> GetAsync()
        {
            return await _context.Bookcases.ToListAsync();
        }

        public async Task<Bookcase> GetByIdAsync(int id)
        {
            return await _context.Bookcases.FindAsync(id);
        }

        public async Task<Bookcase> UpdateAsync(Bookcase bookcase)
        {
            _context.Entry(bookcase).State = EntityState.Detached;
            _context.Bookcases.Update(bookcase);
            await _context.SaveChangesAsync();

            return bookcase;
        }
    }
}
