using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;

namespace LMS.CoreBusiness.Interfaces;

public interface ILibrarianRepository
{
    /// <summary>
    /// Create a new librarian.
    /// </summary>
    /// <param name="librarian">Librarian data</param>
    /// <returns>Newly created librarian.</returns>
    Task<Librarian> CreateAsync(Librarian librarian);

    /// <summary>
    /// Update librarians information.
    /// </summary>
    /// <param name="librarian">Librarians object with data to update.</param>
    /// <returns>Librarian with updated information.</returns>
    Task<Librarian> UpdateAsync(Librarian librarian);

    /// <summary>
    /// Delete librarian with the given Id
    /// </summary>
    /// <param name="id">Librarians unique identifier.</param>
    /// <returns>True if succeded and false otherwise</returns>
    Task<bool> DeleteAsync(int id);

    /// <summary>
    /// Retrieve all librarians.
    /// </summary>
    /// <param name="request">Request paramenters</param>
    Task<PagedList<Librarian>> GetAsync(ResourceRequest request);

    /// <summary>
    /// Get librarian by the given ID
    /// </summary>
    /// <param name="id">Librarian Id</param>
    /// <returns>Librarian with given ID</returns>
    Task<Librarian> GetAsync(int id);
}
