using AutoMapper;
using LMS.Application.ViewModels.Authorship;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class AutorshipProfile : Profile
    {
        public AutorshipProfile()
        {
            CreateMap<Authorship, GetAuthorshipViewModel>();
            CreateMap<GetAuthorshipViewModel, Authorship>();

            CreateMap<Authorship, AddAuthorshipViewModel>();
            CreateMap<AddAuthorshipViewModel, Authorship>();
        }
    }
}
