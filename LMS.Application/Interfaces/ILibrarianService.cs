using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Librarian;

namespace LMS.Application.Interfaces
{
    public interface ILibrarianService
    {
        Task<ServiceResponse<IEnumerable<GetLibrarianViewModel>>> GetAsync();
        Task<ServiceResponse<GetLibrarianViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetLibrarianViewModel>> GetByNameAsync(string name);
        Task<ServiceResponse<GetLibrarianViewModel>> AddAsync(AddLibrarianViewModel author);
        Task<ServiceResponse<GetLibrarianViewModel>> UpdateAsync(GetLibrarianViewModel author);
        Task<ServiceResponse<bool>> DeleteAsync(GetLibrarianViewModel author);
    }
}
