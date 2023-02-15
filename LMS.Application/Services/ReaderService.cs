using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Reader;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _repository;
        private readonly IMapper _mapper;

        public ReaderService(IMapper mapper, IReaderRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetReaderViewModel>> AddAsync(AddReaderViewModel reader)
        {
            var serviceResponse = new ServiceResponse<GetReaderViewModel>();
            try
            {
                var mapper = _mapper.Map<Reader>(reader);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetReaderViewModel>(response);
                serviceResponse.Message = $"Reader with name {string.Concat(reader.FirstName, reader.LastName)} added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetReaderViewModel reader)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Reader>(reader);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Reader deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetReaderViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetReaderViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetReaderViewModel>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReaderViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetReaderViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Reader with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetReaderViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReaderViewModel>> GetByNameAsync(string name)
        {
            var result = await _repository.GetByNameAsync(name);

            var serviceResponse = new ServiceResponse<GetReaderViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Reader with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetReaderViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReaderViewModel>> UpdateAsync(GetReaderViewModel reader)
        {
            var serviceResponse = new ServiceResponse<GetReaderViewModel>();

            try
            {
                var mappedReader = _mapper.Map<Reader>(reader);
                var result = await _repository.UpdateAsync(mappedReader);

                serviceResponse.ResponseData = _mapper.Map<GetReaderViewModel>(result);
                serviceResponse.Message = "Reader updated!";
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
