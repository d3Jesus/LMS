using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Librarian;

namespace LMS.Application.Interfaces
{
    public interface ILibrarianService
    {
        Task<ServiceResponse<GetLibrarianDto>> CreateAsync(AddLibrarianDto librarian);
        Task<ServiceResponse<GetLibrarianDto>> UpdateAsync(GetLibrarianDto librarian);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<IEnumerable<GetLibrarianDto>>> GetAsync(bool wasDeleted);
        Task<ServiceResponse<GetLibrarianDto>> GetByAsync(int id);
        Task<ServiceResponse<GetLibrarianDto>> GetByAsync(string name);
    }
}
