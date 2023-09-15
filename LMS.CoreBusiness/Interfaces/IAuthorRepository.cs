using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IAuthorRepository
    {
        /// <summary>
        /// Create a new author.
        /// </summary>
        /// <param name="author">Author data</param>
        /// <returns>Newly created author.</returns>
        Task<Author> CreateAsync(Author author);

        /// <summary>
        /// Update authors information.
        /// </summary>
        /// <param name="author">Authors object with data to update.</param>
        /// <returns>Author with updated information.</returns>
        Task<Author> UpdateAsync(Author author);

        /// <summary>
        /// Delete author with the given Id
        /// </summary>
        /// <param name="id">Authors unique identifier.</param>
        /// <returns>True if succeded and false otherwise</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Retrieve authors with pagination and sort functionalities.
        /// </summary>
        /// <param name="request">Request paramenters </param>
        /// <returns>List of authors</returns>
        Task<PagedList<GetAuthorsResponse>> GetAsync(GetAuthorsRequest request);

        /// <summary>
        /// Get author by the given ID
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>Author with given ID</returns>
        Task<Author> GetByAsync(int id);
    }
}
