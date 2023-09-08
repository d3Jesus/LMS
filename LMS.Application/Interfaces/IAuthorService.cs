using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;

namespace LMS.Application.Interfaces
{
    public interface IAuthorService
    {
        /// <summary>
        /// Create a new author.
        /// </summary>
        /// <param name="author">Author data</param>
        /// <returns>Newly created author.</returns>
        Task<ServiceResponse<GetAuthorDto>> CreateAsync(AddAuthorDto author);

        /// <summary>
        /// Update authors information.
        /// </summary>
        /// <param name="author">Authors object with data to update.</param>
        /// <returns>Author with updated information.</returns>
        Task<ServiceResponse<GetAuthorDto>> UpdateAsync(GetAuthorDto author);

        /// <summary>
        /// Delete author with the given Id
        /// </summary>
        /// <param name="id">Authors unique identifier.</param>
        /// <returns>True if succeded and false otherwise</returns>
        Task<ServiceResponse<bool>> DeleteAsync(int id);

        /// <summary>
        /// Retrieve all authors.
        /// </summary>
        /// <param name="wasDeleted">Specifies if should retrive deleted authors or not. </param>
        /// <returns>List of authors</returns>
        Task<ServiceResponse<IEnumerable<GetAuthorDto>>> GetAsync(bool wasDeleted = false);

        /// <summary>
        /// Get author by the given ID
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>Author with given ID</returns>
        Task<ServiceResponse<GetAuthorDto>> GetByAsync(int id);

        /// <summary>
        /// Retrieve authors with the given name.
        /// </summary>
        /// <param name="name">Author name.</param>
        /// <returns>List of authors with given name.</returns>
        Task<ServiceResponse<IEnumerable<GetAuthorDto>>> GetByAsync(string name);

        /// <summary>
        /// Retrieve authors with the given nationality.
        /// </summary>
        /// <param name="name">Author name.</param>
        /// <returns>List of authors with given nationality.</returns>
        Task<ServiceResponse<GetAuthorDto>> GetByNationalityAsync(string nationality);
                
    }
}
