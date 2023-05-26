using AutoMapper;
using LMS.Application.ViewModels.Loan;
using LMS.CoreBusiness.ViewModels;

namespace LMS.Application.Profiles
{
    public class PurchaseProfile : Profile
    {
        public PurchaseProfile()
        {
            //CreateMap<Purchase, GetLoanDto>();
            //CreateMap<GetLoanDto, Purchase>();

            CreateMap<AddPurchaseViewModel, AddPurchaseDto>();
            CreateMap<AddPurchaseDto, AddPurchaseViewModel>();
        }
    }
}
