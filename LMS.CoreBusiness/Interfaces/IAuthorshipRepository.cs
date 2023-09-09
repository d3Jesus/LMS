
namespace LMS.CoreBusiness.Interfaces;

public interface IAuthorshipRepository
{
    /// <summary>
    /// Create or update a authorship.
    /// </summary>
    /// <param name="bookId">Book Id</param>
    /// <param name="bookAuthors">Book authors id's</param>
    /// <returns></returns>
    Task<bool> CreateOrUpdateAsync(int bookId, List<int> bookAuthors);
}
