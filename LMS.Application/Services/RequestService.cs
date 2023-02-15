using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Request;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class RequestService : IRequestService
    {
        private readonly IRequestRepository _repository;
        private readonly IMapper _mapper;

        public RequestService(IMapper mapper, IRequestRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetRequestViewModel>> AddAsync(AddRequestViewModel request)
        {
            var serviceResponse = new ServiceResponse<GetRequestViewModel>();
            try
            {
                var mapper = _mapper.Map<Request>(request);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetRequestViewModel>(response);
                serviceResponse.Message = $"Request added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetRequestViewModel request)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Request>(request);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Request deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetRequestViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetRequestViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetRequestViewModel>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRequestViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetRequestViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Request with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetRequestViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetRequestViewModel>> UpdateAsync(GetRequestViewModel request)
        {
            var serviceResponse = new ServiceResponse<GetRequestViewModel>();

            try
            {
                var mappedRequest = _mapper.Map<Request>(request);
                var result = await _repository.UpdateAsync(mappedRequest);

                serviceResponse.ResponseData = _mapper.Map<GetRequestViewModel>(result);
                serviceResponse.Message = "Request updated!";
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
