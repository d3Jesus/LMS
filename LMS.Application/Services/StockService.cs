using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Stock;
using LMS.CoreBusiness.Interfaces;
using Mapster;

namespace LMS.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _repository;

        public StockService(IStockRepository repository) => _repository = repository;

        public async Task<ServiceResponse<IEnumerable<GetStockDto>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetStockDto>>();

            serviceResponse.ResponseData = result.Adapt<IEnumerable<GetStockDto>>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockDto>> GetAsync(int bookId)
        {
            var result = await _repository.GetAsync(bookId);

            var serviceResponse = new ServiceResponse<GetStockDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Book with ID {bookId} not found in stock!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<GetStockDto>();

            return serviceResponse;
        }
    }
}
