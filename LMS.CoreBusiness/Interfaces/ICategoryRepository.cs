using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<Category> DeleteAsync(int id);
        Task<IEnumerable<Category>> GetAsync();
        Task<IEnumerable<Category>> GetAsync(string categoryName);
        Category GetBy(int id);
        Task<Category> GetByAsync(int id);
    }
}
