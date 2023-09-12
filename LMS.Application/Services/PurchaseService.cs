using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
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

        public async Task<ServiceResponse<IEnumerable<GetPurchaseDto>>> GetAsync(DateTime initDate, DateTime endDate, int itemsToTake)
        {
            var result = await _repository.GetAsync(initDate, endDate, itemsToTake);

            var serviceResponse = new ServiceResponse<IEnumerable<GetPurchaseDto>>()
            {
                ResponseData = result.Adapt<IEnumerable<GetPurchaseDto>>()
            };

            return serviceResponse;
        }
    }
}
