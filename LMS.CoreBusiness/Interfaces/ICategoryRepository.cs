using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Create a new category.
        /// </summary>
        /// <param name="category">Category data</param>
        /// <returns>Newly created category.</returns>
        Task<Category> CreateAsync(Category category);

        /// <summary>
        /// Update categorys information.
        /// </summary>
        /// <param name="category">Categories object with data to update.</param>
        /// <returns>Category with updated information.</returns>
        Task<Category> UpdateAsync(Category category);

        /// <summary>
        /// Delete category with the given Id
        /// </summary>
        /// <param name="id">Category unique identifier.</param>
        /// <returns>True if succeded and false otherwise</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Get category by the given ID
        /// </summary>
        /// <returns>Category with given ID</returns>
        Task<IEnumerable<Category>> GetAsync();

        /// <summary>
        /// Retrieve categorys with the given name.
        /// </summary>
        /// <param name="name">Category name.</param>
        /// <returns>List of categorys with given name.</returns>
        Task<IEnumerable<Category>> GetAsync(string categoryName);

        /// <summary>
        /// Get category by the given ID
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Category with given ID</returns>
        Task<Category> GetByAsync(int id);
    }
}
