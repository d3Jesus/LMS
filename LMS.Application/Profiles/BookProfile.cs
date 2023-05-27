using AutoMapper;
using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.ViewModels;

namespace LMS.Application.Profiles;
public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Book, GetBookDto>();
        CreateMap<AddBookDto, AddBookViewModel>();
        CreateMap<GetBookViewModel, GetAllBooksDto>();
        CreateMap<UpdateBookDto, UpdateBookViewModel>();
        CreateMap<GetBookViewModel, GetBookDto>();
    }
}
