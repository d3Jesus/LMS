using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<Purchase> CreateAsync(int librarianId, List<PurchaseItems> items);
        Task<PagedList<GetPurchaseResponse>> GetAsync(GetPurchaseRequest request);
        Task<Purchase> GetAsync(int purchaseId);
    }
}
