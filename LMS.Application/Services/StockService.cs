using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Stock;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class StockService : IStockService
    {
        private readonly IStockRepository _repository;
        private readonly IMapper _mapper;

        public StockService(IMapper mapper, IStockRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetStockDto>> CreateAsync(AddStockDto stock)
        {
            var serviceResponse = new ServiceResponse<GetStockDto>();
            try
            {
                var mapper = _mapper.Map<Stock>(stock);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetStockDto>(response);
                serviceResponse.Message = $"Book added in stock successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockDto>> GetByAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetStockDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Stock with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetStockDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockDto>> UpdateAsync(GetStockDto stock)
        {
            var serviceResponse = new ServiceResponse<GetStockDto>();

            try
            {
                var mappedStock = _mapper.Map<Stock>(stock);
                var result = await _repository.UpdateAsync(mappedStock);

                serviceResponse.ResponseData = _mapper.Map<GetStockDto>(result);
                serviceResponse.Message = "Stock updated!";
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
