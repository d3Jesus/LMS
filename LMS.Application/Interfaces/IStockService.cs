using LMS.Application.ViewModels.Stock;
using LMS.Application.ViewModels;

namespace LMS.Application.Interfaces
{
    public interface IStockService
    {
        Task<ServiceResponse<GetStockDto>> CreateAsync(AddStockDto author);
        Task<ServiceResponse<GetStockDto>> UpdateAsync(GetStockDto author);
        Task<ServiceResponse<GetStockDto>> GetByAsync(int id);
    }
}
