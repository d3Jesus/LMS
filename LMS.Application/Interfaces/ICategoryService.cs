using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Category;

namespace LMS.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<ServiceResponse<GetCategoryDto>> CreateAsync(AddCategoryDto category);
        Task<ServiceResponse<GetCategoryDto>> UpdateAsync(GetCategoryDto category);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAsync();
        Task<ServiceResponse<GetCategoryDto>> GetByAsync(int id); 
        Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAsync(string categoryName);
    }
}

