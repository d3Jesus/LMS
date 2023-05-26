using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Loan;
using LMS.Application.ViewModels.Purchase;

namespace LMS.Application.Interfaces
{
    public interface IPurchaseService
    {
        Task<ServiceResponse<GetPurchaseDto>> AddAsync(AddPurchaseDto loan);
        //Task<ServiceResponse<GetPurchaseDto>> UpdateAsync(GetPurchaseDto loan);
    }
}
