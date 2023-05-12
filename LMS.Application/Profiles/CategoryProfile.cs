using AutoMapper;
using LMS.Application.ViewModels.Category;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, GetCategoryDto>();
            CreateMap<GetCategoryDto, Category>();

            CreateMap<Category, AddCategoryDto>();
            CreateMap<AddCategoryDto, Category>();
        }
    }
}
