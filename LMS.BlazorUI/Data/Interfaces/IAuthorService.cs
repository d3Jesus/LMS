using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAsync();
		Task<ServiceResponse<Author>> CreateAsync(Author author);
	}
}
