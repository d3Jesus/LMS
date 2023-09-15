using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LMS.Infrastructure.Repositories
{
    public class StockRepository : IStockRepository
    {
        private readonly ApplicationDbContext _context;

        public StockRepository(ApplicationDbContext context) => _context = context;

        public async Task AddOrUpdateAsync(Stock stock)
        {
            try
            {
                var existingStock = await GetAsync(stock.BookId);

                if (existingStock is null)
                    await _context.Stocks.AddAsync(stock);
                else
                {
                    existingStock.NumberOfCopies += stock.NumberOfCopies;
                    existingStock.SalePrice = stock.SalePrice;

                    _context.Entry(existingStock).State = EntityState.Modified;
                }
            }
            catch(Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);
            }
        }

        public async Task<Stock> GetAsync(int bookId) 
            => await _context.Stocks.Where(x => x.BookId == bookId).FirstOrDefaultAsync();

        public async Task<IEnumerable<Stock>> GetAsync() 
            => await _context.Stocks.Include(st => st.Book).ToListAsync();

        public void Outbound(Stock stock)
        {
            try
            {
                Stock existingStock = await GetAsync(stock.BookId);
                if (existingStock is not null)
                {
                    existingStock.NumberOfCopies -= stock.NumberOfCopies;
                    _context.Entry(existingStock).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.Message);
            }
        }
    }
}
