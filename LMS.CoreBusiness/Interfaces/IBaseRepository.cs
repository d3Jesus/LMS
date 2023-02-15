namespace LMS.CoreBusiness.Interfaces
{
    public interface IBaseRepository <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T model);
        Task<T> UpdateAsync(T model);
        Task<bool> DeleteAsync(T model);
    }
}
