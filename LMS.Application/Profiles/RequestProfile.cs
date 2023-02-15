using AutoMapper;
using LMS.Application.ViewModels.Request;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class RequestProfile : Profile
    {
        public RequestProfile()
        {
            CreateMap<Request, GetRequestViewModel>();
            CreateMap<GetRequestViewModel, Request>();

            CreateMap<Request, AddRequestViewModel>();
            CreateMap<AddRequestViewModel, Request>();
        }
    }
}
