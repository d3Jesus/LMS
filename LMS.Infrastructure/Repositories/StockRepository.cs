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

        public async Task<Stock> AddAsync(Stock stock)
        {
            _context.Stocks.Add(stock);
            await _context.SaveChangesAsync();

            return stock;
        }

        public async Task<bool> DeleteAsync(Stock stock)
        {
            _context.Entry(stock).State = EntityState.Detached;
            _context.Stocks.Remove(stock);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Stock>> GetAsync()
        {
            return await _context.Stocks.ToListAsync();
        }

        public async Task<Stock> GetByIdAsync(int id)
        {
            return await _context.Stocks.FindAsync(id);
        }

        public async Task<Stock> UpdateAsync(Stock stock)
        {
            _context.Entry(stock).State = EntityState.Detached;
            _context.Stocks.Update(stock);
            await _context.SaveChangesAsync();

            return stock;
        }
    }
}
