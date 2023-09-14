using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;

namespace LMS.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<ServiceResponse<GetPurchaseDto>> AddAsync(int librarianId, List<AddPurchaseItemsDto> items);
        Task<PagedList<GetPurchaseResponse>> GetAsync(GetPurchaseRequest request);
        Task<ServiceResponse<GetPurchaseDto>> GetAsync(int purchaseId);
    }
}
