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


        public async Task<IEnumerable<VwReservation>> GetAllAsync()
        {
            return await _context.VwReservations.ToListAsync();
        }

        public async Task<VwReservation> GetByAsync(int id)
        {
            return await _context.VwReservations.FindAsync(id);
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
