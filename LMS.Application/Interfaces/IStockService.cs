using LMS.Application.ViewModels.Stock;
using LMS.Application.ViewModels;

namespace LMS.Application.Interfaces
{
    public interface IStockService
    {
        Task<ServiceResponse<List<GetStockDto>>> GetAsync();
        Task<ServiceResponse<GetStockDto>> GetAsync(int bookId);
    }
}
