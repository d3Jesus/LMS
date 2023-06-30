using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Purchase;

namespace LMS.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<ServiceResponse<bool>> AddAsync(AddPurchaseDto purchase);
    }
}
