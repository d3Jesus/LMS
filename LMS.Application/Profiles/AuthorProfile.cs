using AutoMapper;
using LMS.Application.ViewModels.Author;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, GetAuthorDto>();
            CreateMap<GetAuthorDto, Author>();

            CreateMap<Author, AddAuthorDto>();
            CreateMap<AddAuthorDto, Author>();
        }
    }
}
