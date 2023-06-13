using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
        Task<ServiceResponse<Author>> GetByAsync(int id);
		Task<ServiceResponse<List<Author>>> GetByName(string authorName);
        Task<ServiceResponse<Author>> CreateAsync(Author author);
		Task<ServiceResponse<Author>> UpdateAsync(Author author);
	}
}
