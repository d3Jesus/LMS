using AutoMapper;
using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.ViewModels;

namespace LMS.Application.Profiles;
public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<GetBookViewModel, GetBookDto>();
        CreateMap<GetBookDto, GetBookViewModel>();

        CreateMap<AddBookViewModel, AddBookDto>();
        CreateMap<AddBookDto, AddBookViewModel>();

        CreateMap<Book, GetBookDto>();
        //CreateMap<GetBookDto, GetBookViewModel>();
    }
}
