using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.ViewModels.Purchase;

namespace LMS.BlazorUI.Data.Interfaces
{
    public interface IPurchaseService
    {
        Task<IEnumerable<GetPurchaseViewModel>> GetAsync(DateTime initDate, DateTime endDate, int itemsToTake);
        Task<ServiceResponse<GetPurchaseViewModel>> CreateAsync(AddPurchaseViewModel model);
	}
}
