using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;

namespace LMS.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<ServiceResponse<GetAuthorDto>> CreateAsync(AddAuthorDto author);
        Task<ServiceResponse<GetAuthorDto>> UpdateAsync(GetAuthorDto author);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<IEnumerable<GetAuthorDto>>> GetAsync(bool wasDeleted);
        Task<ServiceResponse<GetAuthorDto>> GetByAsync(int id);
        Task<ServiceResponse<GetAuthorDto>> GetByAsync(string name);
        Task<ServiceResponse<GetAuthorDto>> GetByNationalityAsync(string nationality);
                
    }
}
