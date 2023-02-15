using AutoMapper;
using LMS.Application.ViewModels.Bookcase;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class BookcaseProfile : Profile
    {
        public BookcaseProfile()
        {
            CreateMap<Bookcase, GetBookcaseViewModel>();
            CreateMap<GetBookcaseViewModel, Bookcase>();

            CreateMap<Bookcase, AddBookcaseViewModel>();
            CreateMap<AddBookcaseViewModel, Bookcase>();
        }
    }
}
