using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private readonly ApplicationDbContext _context;

        public ReaderRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reader> AddAsync(Reader reader)
        {
            _context.Readers.Add(reader);
            await _context.SaveChangesAsync();

            return reader;
        }

        public async Task<bool> DeleteAsync(Reader reader)
        {
            _context.Entry(reader).State = EntityState.Detached;
            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Reader>> GetAsync()
        {
            return await _context.Readers.ToListAsync();
        }

        public async Task<Reader> GetByIdAsync(int id)
        {
            return await _context.Readers.FindAsync(id);
        }

        public async Task<Reader> GetByNameAsync(string name)
        {
            return await _context.Readers
                    .Where(r => r.FirstName.Contains(name) || r.LastName.Contains(name))
                    .FirstOrDefaultAsync();
        }

        public async Task<Reader> UpdateAsync(Reader reader)
        {
            _context.Entry(reader).State = EntityState.Detached;
            _context.Readers.Update(reader);
            await _context.SaveChangesAsync();

            return reader;
        }
    }
}
