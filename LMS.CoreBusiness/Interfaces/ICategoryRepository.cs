using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface ICategoryRepository
    {
        Task<bool> CreateAsync(Category category);
        Task<bool> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<Category>> GetAsync();
        Task<IEnumerable<Category>> GetAsync(string categoryName);
        Category GetBy(int id);
        Task<Category> GetByAsync(int id);
    }
}
