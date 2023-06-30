using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IStockRepository
    {
        Task<bool> CreateAsync(Stock stock);
        Task<bool> UpdateAsync(Stock stock);
        Task<Stock> GetByAsync(int id);
    }
}
