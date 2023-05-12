using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Member> CreateAsync(Member reader)
        {
            _context.Members.Add(reader);
            await _context.SaveChangesAsync();

            return reader;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var member = await _context.Members.FirstOrDefaultAsync(x => x.Id == id);
            _context.Members.Remove(member);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Member>> GetAsync()
        {
            return await _context.Members.ToListAsync();
        }

        public async Task<IEnumerable<Member>> GetByAsync(string name)
        {
            return await _context.Members
                    .Where(r => r.FirstName.Contains(name) || r.LastName.Contains(name))
                    .ToListAsync();
        }

        public async Task<Member> UpdateAsync(Member reader)
        {
            _context.Entry(reader).State = EntityState.Detached;
            _context.Members.Update(reader);
            await _context.SaveChangesAsync();

            return reader;
        }

        public async Task<IEnumerable<Member>> GetAsync(bool wasDeleted)
        {
            return await _context.Members.Where(mb => mb.WasDeleted == wasDeleted).ToListAsync();
        }

        public async Task<Member> GetByAsync(int id)
        {
            return await _context.Members.FindAsync(id);
        }
    }
}
