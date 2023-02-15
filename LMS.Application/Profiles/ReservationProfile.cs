using AutoMapper;
using LMS.Application.ViewModels.Reservation;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, GetReservationViewModel>();
            CreateMap<GetReservationViewModel, Reservation>();

            CreateMap<Reservation, AddReservationViewModel>();
            CreateMap<AddReservationViewModel, Reservation>();
        }
    }
}
