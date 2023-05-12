using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly ApplicationDbContext _context;

        public LoanRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Loan> CreateAsync(Loan loan)
        {
            _context.Loans.Add(loan);
            await _context.SaveChangesAsync();

            return loan;
        }

        public async Task<bool> DeleteAsync(Loan loan)
        {
            _context.Entry(loan).State = EntityState.Detached;
            _context.Loans.Remove(loan);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Loan>> GetAsync()
        {
            return await _context.Loans.ToListAsync();
        }

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _context.Loans.FindAsync(id);
        }

        public async Task<Loan> UpdateAsync(Loan loan)
        {
            _context.Entry(loan).State = EntityState.Detached;
            _context.Loans.Update(loan);
            await _context.SaveChangesAsync();

            return loan;
        }
    }
}
