using AutoMapper;
using LMS.Application.ViewModels.Request;
using LMS.CoreBusiness.Entities;

namespace LMS.Application.Profiles
{
    public class LoanProfile : Profile
    {
        public LoanProfile()
        {
            CreateMap<Loan, GetLoanDto>();
            CreateMap<GetLoanDto, Loan>();

            CreateMap<Loan, AddLoanDto>();
            CreateMap<AddLoanDto, Loan>();
        }
    }
}
