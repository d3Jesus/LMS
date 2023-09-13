using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IPurchaseRepository
    {
        Task<bool> CreateAsync(Purchase purchase, List<PurchaseItems> items);
        Task<PagedList<GetPurchaseResponse>> GetAsync(GetPurchaseRequest request);
    }
}
