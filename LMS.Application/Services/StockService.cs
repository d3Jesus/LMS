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

        public async Task<ServiceResponse<GetStockViewModel>> AddAsync(AddStockViewModel stock)
        {
            var serviceResponse = new ServiceResponse<GetStockViewModel>();
            try
            {
                var mapper = _mapper.Map<Stock>(stock);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetStockViewModel>(response);
                serviceResponse.Message = $"Book added in stock successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetStockViewModel stock)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Stock>(stock);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Book deleted from stock successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetStockViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Stock with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetStockViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStockViewModel>> UpdateAsync(GetStockViewModel stock)
        {
            var serviceResponse = new ServiceResponse<GetStockViewModel>();

            try
            {
                var mappedStock = _mapper.Map<Stock>(stock);
                var result = await _repository.UpdateAsync(mappedStock);

                serviceResponse.ResponseData = _mapper.Map<GetStockViewModel>(result);
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
