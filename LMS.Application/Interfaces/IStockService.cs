using LMS.Application.ViewModels.Stock;
using LMS.Application.ViewModels;

namespace LMS.Application.Interfaces
{
    public interface IStockService
    {
        Task<ServiceResponse<GetStockViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetStockViewModel>> AddAsync(AddStockViewModel author);
        Task<ServiceResponse<GetStockViewModel>> UpdateAsync(GetStockViewModel author);
        Task<ServiceResponse<bool>> DeleteAsync(GetStockViewModel author);
    }
}
