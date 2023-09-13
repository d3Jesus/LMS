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

        public async Task<ServiceResponse<bool>> AddAsync(AddPurchaseDto purchase)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                var newPurchase = purchase.Adapt<Purchase>();
                var newPurchaseitems = purchase.items.Adapt<List<PurchaseItems>>();
                var response = await _repository.CreateAsync(newPurchase, newPurchaseitems);

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
    }
}
