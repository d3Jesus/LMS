namespace LMS.CoreBusiness.Interfaces
{
    public interface IPerson<T> where T : class
    {
        Task<T> CreateAsync(T person);
        Task<T> UpdateAsync(T person);
        Task<bool> DeleteAsync(int id);
        Task<IEnumerable<T>> GetAsync(bool wasDeleted);
        Task<T> GetByAsync(int id);
        Task<IEnumerable<T>> GetByAsync(string name);
    }
}
