using AutoMapper;
using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles;
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<Book, GetBookViewModel>();
            CreateMap<GetBookViewModel, Book>();

            CreateMap<Book, AddBookViewModel>();
            CreateMap<AddBookViewModel, Book>();
        }
    }
