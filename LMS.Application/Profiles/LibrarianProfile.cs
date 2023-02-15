using AutoMapper;
using LMS.Application.ViewModels.Librarian;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class LibrarianProfile : Profile
    {
        public LibrarianProfile()
        {
            CreateMap<Librarian, GetLibrarianViewModel>();
            CreateMap<GetLibrarianViewModel, Librarian>();

            CreateMap<Librarian, AddLibrarianViewModel>();
            CreateMap<AddLibrarianViewModel, Librarian>();
        }
    }
}
