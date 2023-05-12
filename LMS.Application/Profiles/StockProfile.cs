using AutoMapper;
using LMS.Application.ViewModels.Stock;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class StockProfile : Profile
    {
        public StockProfile()
        {
            CreateMap<Stock, GetStockDto>();
            CreateMap<GetStockDto, Stock>();

            CreateMap<Stock, AddStockDto>();
            CreateMap<AddStockDto, Stock>();
        }
    }
}
