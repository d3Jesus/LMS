using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IAuthorshipRepository
    {
        Task<Authorship> AddAsync(Authorship model);
        Task<Authorship> UpdateAsync(Authorship model);
        Task<bool> DeleteAsync(Authorship model);
    }
}
