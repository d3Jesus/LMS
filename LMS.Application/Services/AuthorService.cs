using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
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
                serviceResponse.Message = $"Author with name {string.Concat(model.FirstName, " ", model.LastName)} added successfully!";
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

        public async Task<PagedList<GetAuthorsResponse>> GetAsync(GetAuthorsRequest request) 
            => await _repository.GetAsync(request);

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

        public async Task<ServiceResponse<GetAuthorDto>> UpdateAsync(UpdateAuthorDto model)
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
