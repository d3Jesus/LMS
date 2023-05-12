using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock> CreateAsync(Stock stock);
        Task<Stock> UpdateAsync(Stock stock);
        Task<Stock> GetByAsync(int id);
    }
}
