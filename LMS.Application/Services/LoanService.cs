using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Request;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class LoanService : ILoanService
    {
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public LoanService(IMapper mapper, ILoanRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetLoanDto>> AddAsync(AddLoanDto loan)
        {
            var serviceResponse = new ServiceResponse<GetLoanDto>();
            try
            {
                var mapper = _mapper.Map<Loan>(loan);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetLoanDto>(response);
                serviceResponse.Message = $"Request added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLoanDto>> UpdateAsync(GetLoanDto loan)
        {
            var serviceResponse = new ServiceResponse<GetLoanDto>();

            try
            {
                var mappedRequest = _mapper.Map<Loan>(loan);
                var result = await _repository.UpdateAsync(mappedRequest);

                serviceResponse.ResponseData = _mapper.Map<GetLoanDto>(result);
                serviceResponse.Message = "Request updated!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
    }
}
