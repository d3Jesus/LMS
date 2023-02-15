using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.PublishingCompany;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class PublishingCompanyService : IPublishingCompanyService
    {
        private readonly IPublishingCompanyRepository _repository;
        private readonly IMapper _mapper;

        public PublishingCompanyService(IMapper mapper, IPublishingCompanyRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetPublishingCompanyViewModel>> AddAsync(AddPublishingCompanyViewModel publishingCompany)
        {
            var serviceResponse = new ServiceResponse<GetPublishingCompanyViewModel>();
            try
            {
                var mapper = _mapper.Map<PublishingCompany>(publishingCompany);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetPublishingCompanyViewModel>(response);
                serviceResponse.Message = $"Publishing Company with name {publishingCompany.Name} added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetPublishingCompanyViewModel publishingCompany)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<PublishingCompany>(publishingCompany);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "PublishingCompany deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetPublishingCompanyViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetPublishingCompanyViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetPublishingCompanyViewModel>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPublishingCompanyViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetPublishingCompanyViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"PublishingCompany with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetPublishingCompanyViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPublishingCompanyViewModel>> GetByNameAsync(string name)
        {
            var result = await _repository.GetByNameAsync(name);

            var serviceResponse = new ServiceResponse<GetPublishingCompanyViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"PublishingCompany with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetPublishingCompanyViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetPublishingCompanyViewModel>> UpdateAsync(GetPublishingCompanyViewModel publishingCompany)
        {
            var serviceResponse = new ServiceResponse<GetPublishingCompanyViewModel>();

            try
            {
                var mappedPublishingCompany = _mapper.Map<PublishingCompany>(publishingCompany);
                var result = await _repository.UpdateAsync(mappedPublishingCompany);

                serviceResponse.ResponseData = _mapper.Map<GetPublishingCompanyViewModel>(result);
                serviceResponse.Message = "PublishingCompany updated!";
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
