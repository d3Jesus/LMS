using AutoMapper;
using LMS.Application.ViewModels.Librarian;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class LibrarianProfile : Profile
    {
        public LibrarianProfile()
        {
            CreateMap<Librarian, GetLibrarianDto>();
            CreateMap<GetLibrarianDto, Librarian>();

            CreateMap<Librarian, AddLibrarianDto>();
            CreateMap<AddLibrarianDto, Librarian>();
        }
    }
}
