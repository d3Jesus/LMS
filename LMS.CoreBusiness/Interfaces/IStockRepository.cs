using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IStockRepository
    {
        Task AddOrUpdateAsync(Stock stock);

        void Outbound(Stock stock);

        Task<Stock> GetAsync(int bookId);

        Task<IEnumerable<Stock>> GetAsync();
    }
}
