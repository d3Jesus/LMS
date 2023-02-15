using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class RequestRepository : IRequestRepository
    {
        private readonly ApplicationDbContext _context;

        public RequestRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Request> AddAsync(Request request)
        {
            _context.Requests.Add(request);
            await _context.SaveChangesAsync();

            return request;
        }

        public async Task<bool> DeleteAsync(Request request)
        {
            _context.Entry(request).State = EntityState.Detached;
            _context.Requests.Remove(request);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Request>> GetAsync()
        {
            return await _context.Requests.ToListAsync();
        }

        public async Task<Request> GetByIdAsync(int id)
        {
            return await _context.Requests.FindAsync(id);
        }

        public async Task<Request> UpdateAsync(Request request)
        {
            _context.Entry(request).State = EntityState.Detached;
            _context.Requests.Update(request);
            await _context.SaveChangesAsync();

            return request;
        }
    }
}
