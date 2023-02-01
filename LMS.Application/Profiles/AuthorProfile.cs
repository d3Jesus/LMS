using AutoMapper;
using LMS.Application.ViewModels.Author;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, GetAuthorViewModel>();
            CreateMap<GetAuthorViewModel, Author>();

            CreateMap<Author, AddAuthorViewModel>();
            CreateMap<AddAuthorViewModel, Author>();
        }
    }
}
