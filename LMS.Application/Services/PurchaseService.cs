using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

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

        public async Task<ServiceResponse<bool>> AddAsync(AddPurchaseDto purchase)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                var newPurchase = _mapper.Map<Purchase>(purchase);
                var newPurchaseitems = _mapper.Map<List<PurchaseItems>>(purchase.items);
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

        public async Task<ServiceResponse<IEnumerable<GetPurchaseDto>>> GetAsync(DateTime initDate, DateTime endDate)
        {
            var result = await _repository.GetAsync(initDate, endDate);

            var serviceResponse = new ServiceResponse<IEnumerable<GetPurchaseDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetPurchaseDto>>(result)
            };

            return serviceResponse;
        }
    }
}
