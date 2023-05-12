using AutoMapper;
using LMS.Application.ViewModels.Reservation;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class ReservationProfile : Profile
    {
        public ReservationProfile()
        {
            CreateMap<Reservation, GetReservationDto>();
            CreateMap<GetReservationDto, Reservation>();

            CreateMap<Reservation, AddReservationDto>();
            CreateMap<AddReservationDto, Reservation>();
        }
    }
}
