using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Librarian;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;

namespace LMS.Application.Interfaces
{
    public interface ILibrarianService
    {
        /// <summary>
        /// Create a new librarian.
        /// </summary>
        /// <param name="librarian">Librarian data</param>
        /// <returns>Newly created librarian.</returns>
        Task<ServiceResponse<GetLibrarianDto>> CreateAsync(AddLibrarianDto librarian);

        /// <summary>
        /// Update librarian's information.
        /// </summary>
        /// <param name="librarian">Librarians object with data to update.</param>
        /// <returns>Librarian with updated information.</returns>
        Task<ServiceResponse<GetLibrarianDto>> UpdateAsync(UpdateLibrarianDto librarian);

        /// <summary>
        /// Delete librarian with the given Id
        /// </summary>
        /// <param name="id">Librarians unique identifier.</param>
        /// <returns>True if succeded and false otherwise</returns>
        Task<ServiceResponse<bool>> DeleteAsync(int id);

        /// <summary>
        /// Retrieve all librarians.
        /// </summary>
        /// <param name="request">Request parameters.</param>
        Task<PagedList<Librarian>> GetAsync(ResourceRequest request);

        /// <summary>
        /// Get librarian by the given ID
        /// </summary>
        /// <param name="id">Librarian Id</param>
        /// <returns>Librarian with given ID</returns>
        Task<ServiceResponse<GetLibrarianDto>> GetByAsync(int id);
    }
}
