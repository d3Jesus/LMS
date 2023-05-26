using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.ViewModels;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Purchase> CreateAsync(AddPurchaseViewModel purchase);
        //Task<Purchase> UpdateAsync(AddPurchaseViewModel purchase);

    }
}
