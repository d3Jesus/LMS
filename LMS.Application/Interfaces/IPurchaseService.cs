using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;

namespace LMS.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<ServiceResponse<bool>> AddAsync(AddPurchaseDto purchase);
        Task<PagedList<GetPurchaseResponse>> GetAsync(GetPurchaseRequest request);
    }
}
