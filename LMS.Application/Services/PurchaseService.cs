using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Loan;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.ViewModels;

namespace LMS.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repository;
        private readonly IMapper _mapper;

        public PurchaseService(IMapper mapper, IPurchaseRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetPurchaseDto>> AddAsync(AddPurchaseDto loan)
        {
            var serviceResponse = new ServiceResponse<GetPurchaseDto>();
            try
            {
                var mapper = _mapper.Map<AddPurchaseViewModel>(loan);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetPurchaseDto>(response);
                serviceResponse.Message = $"Request added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        //public async Task<ServiceResponse<GetPurchaseDto>> UpdateAsync(GetPurchaseDto loan)
        //{
        //    var serviceResponse = new ServiceResponse<GetPurchaseDto>();

        //    try
        //    {
        //        var mappedRequest = _mapper.Map<AddPurchaseViewModel>(loan);
        //        var result = await _repository.UpdateAsync(mappedRequest);

        //        serviceResponse.ResponseData = _mapper.Map<GetPurchaseDto>(result);
        //        serviceResponse.Message = "Request updated!";
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.Succeeded = false;
        //        serviceResponse.Message = ex.Message;
        //    }

        //    return serviceResponse;
        //}
    }
}
