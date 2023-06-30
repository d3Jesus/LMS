using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<bool> CreateAsync(Purchase purchase, List<PurchaseItems> items);
        Task<IEnumerable<Purchase>> GetAsync(DateTime initDate, DateTime endDate);
    }
}
