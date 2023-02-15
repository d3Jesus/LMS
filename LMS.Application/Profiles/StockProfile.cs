using AutoMapper;
using LMS.Application.ViewModels.Stock;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, GetStockViewModel>();
            CreateMap<GetStockViewModel, Stock>();

            CreateMap<Stock, AddStockViewModel>();
            CreateMap<AddStockViewModel, Stock>();
        }
    }
}
