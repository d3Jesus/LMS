using AutoMapper;
using LMS.Application.ViewModels.Reader;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class ReaderProfile : Profile
    {
        public ReaderProfile()
        {
            CreateMap<Reader, GetReaderViewModel>();
            CreateMap<GetReaderViewModel, Reader>();

            CreateMap<Reader, AddReaderViewModel>();
            CreateMap<AddReaderViewModel, Reader>();
        }
    }
}
