﻿using LMS.CoreBusiness.Entities;

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
        /// Retrieve all authors.
        /// </summary>
        /// <param name="wasDeleted">Specifies if should retrieve deleted authors or not. </param>
        /// <returns>List of authors</returns>
        Task<IEnumerable<Author>> GetAsync(bool wasDeleted);

        /// <summary>
        /// Get author by the given ID
        /// </summary>
        /// <param name="id">Author Id</param>
        /// <returns>Author with given ID</returns>
        Task<Author> GetByAsync(int id);

        /// <summary>
        /// Retrieve authors with the given name.
        /// </summary>
        /// <param name="name">Author name.</param>
        /// <returns>List of authors with given name.</returns>
        Task<IEnumerable<Author>> GetByAsync(string name);

        /// <summary>
        /// Retrieve authors with the given nationality.
        /// </summary>
        /// <param name="name">Author name.</param>
        /// <returns>List of authors with given nationality.</returns>
        Task<Author> GetByNationalityAsync(string nationality);
    }
}
