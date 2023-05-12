using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface ILoanRepository
    {
        Task<Loan> CreateAsync(Loan loan);
        Task<Loan> UpdateAsync(Loan loan);

    }
}
