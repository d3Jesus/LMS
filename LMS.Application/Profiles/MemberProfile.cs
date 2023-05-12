using AutoMapper;
using LMS.Application.ViewModels.Reader;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class MemberProfile : Profile
    {
        public MemberProfile()
        {
            CreateMap<Member, GetMemberDto>();
            CreateMap<GetMemberDto, Member>();

            CreateMap<Member, AddMemberDto>();
            CreateMap<AddMemberDto, Member>();
        }
    }
}
