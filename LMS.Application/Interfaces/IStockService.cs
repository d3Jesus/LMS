using LMS.Application.ViewModels.Stock;
using LMS.Application.ViewModels;

namespace LMS.Application.Interfaces
{
    public interface IStockService
    {
        Task<ServiceResponse<IEnumerable<GetStockDto>>> GetAsync();
        Task<ServiceResponse<GetStockDto>> GetAsync(int bookId);
    }
}
