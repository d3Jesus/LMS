using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using LMS.CoreBusiness.UnitsOfWork;
using Mapster;

namespace LMS.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseUnitOfWork _unitOfWork;

        public PurchaseService(IPurchaseUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

        public async Task<ServiceResponse<GetPurchaseDto>> AddAsync(int librarianId, List<AddPurchaseItemsDto> items)
        {
            try
            {
                _unitOfWork.BeginTransaction();
                
                var purchaseitems = items.Adapt<List<PurchaseItems>>();
                var response = await _unitOfWork.PurchaseRepository.CreateAsync(librarianId, purchaseitems);

                foreach(var item in items) 
                {
                    Stock stock = new()
                    {
                        BookId = item.BookId,
                        NumberOfCopies = item.NumberOfCopies
                    };

                    await _unitOfWork.StockRepository.Outbound(stock);
                }

                if (_unitOfWork.CommitTransaction())
                    return new ServiceResponse<GetPurchaseDto>
                    {
                        ResponseData = response.Adapt<GetPurchaseDto>(),
                        Succeeded = true,
                        Message = "Purhcase registered successfuly."
                    };

                return new ServiceResponse<GetPurchaseDto>
                {
                    Succeeded = false,
                    Message = "Failed to register purchase."
                };
            }
            catch (Exception ex)
            {
                _unitOfWork.RollbackTransaction();
                return new ServiceResponse<GetPurchaseDto>
                {
                    Succeeded = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<PagedList<GetPurchaseResponse>> GetAsync(GetPurchaseRequest request) 
            => await _unitOfWork.PurchaseRepository.GetAsync(request);

        public async Task<ServiceResponse<GetPurchaseDto>> GetAsync(int purchaseId)
        {
            var serviceResponse = new ServiceResponse<GetPurchaseDto>();
            try
            {
                var response = await _unitOfWork.PurchaseRepository.GetAsync(purchaseId);

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
