using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using Mapster;

namespace LMS.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;

        public AuthorService(IAuthorRepository repository) => _repository = repository;

        public async Task<ServiceResponse<GetAuthorDto>> CreateAsync(AddAuthorDto model)
        {
            var serviceResponse = new ServiceResponse<GetAuthorDto>();
            try
            {
                Author author = model.Adapt<Author>();
                var response = await _repository.CreateAsync(author);

                serviceResponse.ResponseData = response.Adapt<GetAuthorDto>();
                serviceResponse.Message = $"Author with name {string.Concat(model.firstName, " ", model.lastName)} added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                await _repository.DeleteAsync(id);

                serviceResponse.Message = "Author deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetAuthorDto>>> GetAsync(bool wasDeleted = false)
        {
            var result = await _repository.GetAsync(wasDeleted);

            var serviceResponse = new ServiceResponse<IEnumerable<GetAuthorDto>>()
            {
                ResponseData = result.Adapt<IEnumerable<GetAuthorDto>>()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorDto>> GetByAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetAuthorDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Author with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<GetAuthorDto>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetAuthorDto>>> GetByAsync(string name)
        {
            var result = await _repository.GetByAsync(name);

            var serviceResponse = new ServiceResponse<IEnumerable<GetAuthorDto>>();
            if (result is null)
            {
                serviceResponse.Message = $"Author with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<IEnumerable<GetAuthorDto>>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorDto>> GetByNationalityAsync(string nationality)
        {
            var result = await _repository.GetByAsync(nationality);

            var serviceResponse = new ServiceResponse<GetAuthorDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Authors with nationality {nationality} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<GetAuthorDto>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorDto>> UpdateAsync(GetAuthorDto model)
        {
            var serviceResponse = new ServiceResponse<GetAuthorDto>();

            try
            {
                var author = model.Adapt<Author>();
                var result = await _repository.UpdateAsync(author);

                serviceResponse.ResponseData = result.Adapt<GetAuthorDto>();
                serviceResponse.Message = "Author updated!";
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
