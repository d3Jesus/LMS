using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface IReservationRepository
    {
        Task<Reservation> CreateAsync(Reservation reservation);
        Task<Reservation> UpdateAsync(Reservation reservation);
        Task<Reservation> GetByAsync(int id);
    }
}
