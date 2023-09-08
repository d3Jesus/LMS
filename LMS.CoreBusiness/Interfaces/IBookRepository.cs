using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IBookRepository
    {
        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="book">Book data</param>
        /// <returns>Newly created book.</returns>
        Task<Book> CreateAsync(Book book);

        /// <summary>
        /// Update books information.
        /// </summary>
        /// <param name="book">Books object with data to update.</param>
        /// <returns>Book with updated information.</returns>
        Task<Book> UpdateAsync(Book book);

        /// <summary>
        /// Delete book with the given Id
        /// </summary>
        /// <param name="id">Books unique identifier.</param>
        /// <returns>True if succeded and false otherwise</returns>
        Task<bool> DeleteAsync(int id);

        /// <summary>
        /// Retrieve book with the given ID
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Book with given ID</returns>
        Task<Book> GetByAsync(int id);

        /// <summary>
        /// Retrieve all books
        /// </summary>
        /// <returns>List of books</returns>
        Task<IEnumerable<Book>> GetAsync();

        /// <summary>
        /// Get book with the given book title
        /// </summary>
        /// <param name="title">Book title</param>
        /// <returns>Book with given title</returns>
        Task<IEnumerable<Book>> GetAsync(string title);

        /// <summary>
        /// Get book by the given category
        /// </summary>
        /// <param name="category">Book category</param>
        /// <returns>Book with given category</returns>
        Task<IEnumerable<Book>> GetAsync(int category);
    }
}
