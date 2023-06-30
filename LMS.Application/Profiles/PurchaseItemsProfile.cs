using AutoMapper;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class PurchaseItemsProfile : Profile
    {
        public PurchaseItemsProfile()
        {            
            CreateMap<PurchaseItems, AddPurchaseItemsDto>();
            CreateMap<AddPurchaseItemsDto, PurchaseItems>();
        }
    }
}
