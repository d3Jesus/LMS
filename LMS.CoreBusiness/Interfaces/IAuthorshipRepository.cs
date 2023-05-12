using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IAuthorshipRepository
    {
        Task<Authorship> CreateAsync(Authorship model);
        Task<Authorship> UpdateAsync(Authorship model);
    }
}
