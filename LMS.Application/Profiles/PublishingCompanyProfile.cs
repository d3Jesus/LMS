using AutoMapper;
using LMS.Application.ViewModels.PublishingCompany;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class PublishingCompanyProfile : Profile
    {
        public PublishingCompanyProfile()
        {
            CreateMap<PublishingCompany, GetPublishingCompanyViewModel>();
            CreateMap<GetPublishingCompanyViewModel, PublishingCompany>();

            CreateMap<PublishingCompany, AddPublishingCompanyViewModel>();
            CreateMap<AddPublishingCompanyViewModel, PublishingCompany>();
        }
    }
}
