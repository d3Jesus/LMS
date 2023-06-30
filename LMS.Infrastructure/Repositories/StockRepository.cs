using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Stock> GetByAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<bool> UpdateAsync(Stock stock)
        {
            _context.Entry(stock).State = EntityState.Detached;
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
