using LMS.BlazorUI.Data.Models;

namespace LMS.BlazorUI.Data.Interfaces
{
    public interface ILibrarianService
    {
        Task<ServiceResponse<IEnumerable<Librarian>>> GetAsync();
        Task<ServiceResponse<Librarian>> GetByAsync(int id);
        Task<ServiceResponse<Librarian>> CreateAsync(Librarian librarian);
        Task<ServiceResponse<Librarian>> UpdateAsync(Librarian librarian);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
    }
}
