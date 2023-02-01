using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;

namespace LMS.Application.Interfaces
{
    public interface IAuthorService
    {
        Task<ServiceResponse<IEnumerable<GetAuthorViewModel>>> GetAsync();
        Task<ServiceResponse<GetAuthorViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetAuthorViewModel>> GetByNameAsync(string name);
        Task<ServiceResponse<GetAuthorViewModel>> GetByNationalityAsync(string nationality);

        Task<ServiceResponse<GetAuthorViewModel>> AddAsync(AddAuthorViewModel author);
        Task<ServiceResponse<GetAuthorViewModel>> UpdateAsync(GetAuthorViewModel author);
        Task<ServiceResponse<bool>> DeleteAsync(GetAuthorViewModel author);
        
    }
}
