using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDbContext _context;

        public ReservationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Reservation> CreateAsync(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }

        public async Task<bool> DeleteAsync(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Detached;
            _context.Reservations.Remove(reservation);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Reservation>> GetAsync()
        {
            return await _context.Reservations.ToListAsync();
        }

        public async Task<Reservation> GetByAsync(int id)
        {
            return await _context.Reservations.FindAsync(id);
        }

        public async Task<Reservation> UpdateAsync(Reservation reservation)
        {
            _context.Entry(reservation).State = EntityState.Detached;
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();

            return reservation;
        }
    }
}
