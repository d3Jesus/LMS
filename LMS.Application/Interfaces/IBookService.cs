using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Book;

namespace LMS.Application.Interfaces
{
    public interface IBookService
    {
        /// <summary>
        /// Create a new book.
        /// </summary>
        /// <param name="model">Book data</param>
        /// <returns>Newly created book.</returns>
        Task<ServiceResponse<GetBookDto>> CreateAsync(AddBookDto model);

        /// <summary>
        /// Update books information.
        /// </summary>
        /// <param name="model">Books object with data to update.</param>
        /// <returns>Book with updated information.</returns>
        Task<ServiceResponse<GetBookDto>> UpdateAsync(UpdateBookDto model);

        /// <summary>
        /// Delete book with the given Id
        /// </summary>
        /// <param name="id">Books unique identifier.</param>
        /// <returns>True if succeded and false otherwise</returns
        Task<ServiceResponse<bool>> DeleteAsync(int id);

        /// <summary>
        /// Retrieve book with the given ID
        /// </summary>
        /// <param name="id">Book Id</param>
        /// <returns>Book with given ID</returns>
        Task<ServiceResponse<GetBookDto>> GetByIdAsync(int id);

        /// <summary>
        /// Retrieve all books
        /// </summary>
        /// <returns>List of books</returns>
        Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAsync();

        /// <summary>
        /// Get book with the given book title
        /// </summary>
        /// <param name="title">Book title</param>
        /// <returns>Book with given title</returns>
        Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAsync(string title);

        /// <summary>
        /// Get book by the given category
        /// </summary>
        /// <param name="category">Book category</param>
        /// <returns>Book with given category</returns>
        Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAsync(int category);
    }
}
