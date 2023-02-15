using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class PublishingCompanyRepository : IPublishingCompanyRepository
    {
        private readonly ApplicationDbContext _context;

        public PublishingCompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<PublishingCompany> AddAsync(PublishingCompany publishingCompany)
        {
            _context.PublishingCompanies.Add(publishingCompany);
            await _context.SaveChangesAsync();

            return publishingCompany;
        }

        public async Task<bool> DeleteAsync(PublishingCompany publishingCompany)
        {
            _context.Entry(publishingCompany).State = EntityState.Detached;
            _context.PublishingCompanies.Remove(publishingCompany);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<PublishingCompany>> GetAsync()
        {
            return await _context.PublishingCompanies.ToListAsync();
        }

        public async Task<PublishingCompany> GetByIdAsync(int id)
        {
            return await _context.PublishingCompanies.FindAsync(id);
        }

        public async Task<PublishingCompany> GetByNameAsync(string name)
        {
            return await _context.PublishingCompanies
                    .Where(a => a.Name == name)
                    .FirstOrDefaultAsync();
        }

        public async Task<PublishingCompany> UpdateAsync(PublishingCompany publishingCompany)
        {
            _context.Entry(publishingCompany).State = EntityState.Detached;
            _context.PublishingCompanies.Update(publishingCompany);
            await _context.SaveChangesAsync();

            return publishingCompany;
        }
    }
}
