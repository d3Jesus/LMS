using LMS.Application.ViewModels;

namespace LMS.Application.Interfaces;

public interface IAuthorshipService
{
    /// <summary>
    /// Create or update a authorship.
    /// </summary>
    /// <param name="bookId">Book Id</param>
    /// <param name="bookAuthors">Book authors id's</param>
    /// <returns></returns>
    Task<ServiceResponse<bool>> CreateOrUpdateAsync(int bookId, List<int> bookAuthors);
}
