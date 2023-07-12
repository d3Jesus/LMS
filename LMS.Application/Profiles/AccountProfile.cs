using AutoMapper;
using LMS.Application.ViewModels.UserAccount;
using LMS.CoreBusiness.Entities.Accounts;

namespace LMS.Application.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<UserRegistrationDto, UserRegistration>();
            CreateMap<UserLoginDto, UserLogin>();

            CreateMap<Roles, RolesDto>();
        }
    }
}
