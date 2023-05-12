using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IAuthorRepository : IPerson<Author>
    {
        Task<Author> GetByNationalityAsync(string nationality);
    }
}
