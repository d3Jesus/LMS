using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Category;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;

namespace LMS.Application.Interfaces
{
    public interface ICategoryService
    {
        /// <summary>
        /// Create a new category.
        /// </summary>
        /// <param name="categoryDto">Category data</param>
        /// <returns>Newly created category.</returns>
        Task<ServiceResponse<GetCategoryDto>> CreateAsync(AddCategoryDto categoryDto);

        /// <summary>
        /// Update categorys information.
        /// </summary>
        /// <param name="categoryDto">Categories object with data to update.</param>
        /// <returns>Category with updated information.</returns>
        Task<ServiceResponse<GetCategoryDto>> UpdateAsync(UpdateCategoryDto categoryDto);

        /// <summary>
        /// Delete category with the given Id
        /// </summary>
        /// <param name="id">Category unique identifier.</param>
        /// <returns>True if succeded and false otherwise</returns>
        Task<ServiceResponse<bool>> DeleteAsync(int id);

        /// <summary>
        /// Get category by the given ID
        /// </summary>
        /// <returns>Category with given ID</returns>
        Task<PagedList<GetCategoryResponse>> GetAsync(ResourceRequest request);

        /// <summary>
        /// Retrieve categorys with the given name.
        /// </summary>
        /// <param name="name">Category name.</param>
        /// <returns>List of categorys with given name.</returns>
        Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAsync(string categoryName);

        /// <summary>
        /// Get category by the given ID
        /// </summary>
        /// <param name="id">Category Id</param>
        /// <returns>Category with given ID</returns>
        Task<ServiceResponse<GetCategoryDto>> GetByAsync(int id);
    }
}

