using AutoMapper;
using LMS.Application.ViewModels.UserAccount;
using LMS.CoreBusiness.Entities.Accounts;

namespace LMS.Application.Profiles
{
    public class AccountProfile : Profile
    {
        public AccountProfile()
        {
            CreateMap<AccountDto, Account>();

            CreateMap<Roles, RolesDto>();
        }
    }
}
