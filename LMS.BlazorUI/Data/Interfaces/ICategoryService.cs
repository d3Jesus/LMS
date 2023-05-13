using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Interfaces
{
    public interface ICategoryService
    {
        //Task<ServiceResponse<Category>> CreateAsync(Category category);
        //Task<ServiceResponse<Category>> UpdateAsync(Category category);
        //Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<IEnumerable<Category>> GetAsync();
        //Task<ServiceResponse<Category>> GetByAsync(int id);
        //Task<ServiceResponse<IEnumerable<Category>>> GetAsync(string categoryName);
    }
}
