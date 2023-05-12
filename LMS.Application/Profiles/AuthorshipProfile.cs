using AutoMapper;
using LMS.Application.ViewModels.Authorship;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class AuthorshipProfile : Profile
    {
        public AuthorshipProfile()
        {
            CreateMap<Authorship, GetAuthorshipDto>();
            CreateMap<GetAuthorshipDto, Authorship>();

            CreateMap<Authorship, AddAuthorshipDto>();
            CreateMap<AddAuthorshipDto, Authorship>();
        }
    }
}
