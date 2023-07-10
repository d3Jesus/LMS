using AutoMapper;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            CreateMap<AddPurchaseDto, Purchase>();
            CreateMap<Purchase, AddPurchaseDto>();

            CreateMap<GetPurchaseDto, Purchase>();
            CreateMap<Purchase, GetPurchaseDto>();
        }
    }
}
