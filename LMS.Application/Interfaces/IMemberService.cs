using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Reader;

namespace LMS.Application.Interfaces
{
    public interface IMemberService
    {
        Task<ServiceResponse<GetMemberDto>> CreateAsync(AddMemberDto member);
        Task<ServiceResponse<GetMemberDto>> UpdateAsync(GetMemberDto member);
        Task<ServiceResponse<bool>> DeleteAsync(int id);
        Task<ServiceResponse<IEnumerable<GetMemberDto>>> GetAsync(bool wasDeleted);
        Task<ServiceResponse<GetMemberDto>> GetByAsync(int id);
        Task<ServiceResponse<GetMemberDto>> GetByAsync(string name);
    }
}
