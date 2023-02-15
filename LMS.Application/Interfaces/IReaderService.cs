using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Reader;

namespace LMS.Application.Interfaces
{
    public interface IReaderService
    {
        Task<ServiceResponse<IEnumerable<GetReaderViewModel>>> GetAsync();
        Task<ServiceResponse<GetReaderViewModel>> GetByIdAsync(int id);
        Task<ServiceResponse<GetReaderViewModel>> GetByNameAsync(string name);
        Task<ServiceResponse<GetReaderViewModel>> AddAsync(AddReaderViewModel author);
        Task<ServiceResponse<GetReaderViewModel>> UpdateAsync(GetReaderViewModel author);
        Task<ServiceResponse<bool>> DeleteAsync(GetReaderViewModel author);
    }
}
