using AutoMapper;
using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles;
public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<GetBookDto, Book>();
        CreateMap<Book, GetBookDto>();

        CreateMap<Book, AddBookDto>();
        CreateMap<AddBookDto, Book>();

        CreateMap<Book, UpdateBookDto>();
        CreateMap<UpdateBookDto, Book>();
    }
}
