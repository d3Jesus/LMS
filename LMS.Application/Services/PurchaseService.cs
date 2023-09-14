using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using Mapster;

namespace LMS.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _repository;

        public PurchaseService(IPurchaseRepository repository) => _repository = repository;

        public async Task<ServiceResponse<GetPurchaseDto>> AddAsync(int librarianId, List<AddPurchaseItemsDto> items)
        {
            var serviceResponse = new ServiceResponse<GetPurchaseDto>();
            try
            {
                var purchaseitems = items.Adapt<List<PurchaseItems>>();
                var response = await _repository.CreateAsync(librarianId, purchaseitems);

                serviceResponse.ResponseData = response.Adapt<GetPurchaseDto>();
                serviceResponse.Message = $"Purchase successfully registed!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<PagedList<GetPurchaseResponse>> GetAsync(GetPurchaseRequest request) 
            => await _repository.GetAsync(request);

        public async Task<ServiceResponse<GetPurchaseDto>> GetAsync(int purchaseId)
        {
            var serviceResponse = new ServiceResponse<GetPurchaseDto>();
            try
            {
                var response = await _repository.GetAsync(purchaseId);

                serviceResponse.ResponseData = response.Adapt<GetPurchaseDto>();
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
