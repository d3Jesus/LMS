using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Category;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using Mapster;

namespace LMS.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository) => _repository = repository;

        public async Task<ServiceResponse<GetCategoryDto>> CreateAsync(AddCategoryDto categoryDto)
        {
            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            try
            {
                var category = categoryDto.Adapt<Category>();
                var response = await _repository.CreateAsync(category);

                serviceResponse.ResponseData = categoryDto.Adapt<GetCategoryDto>();
                serviceResponse.Message = $"Category {categoryDto.CategoryName} was added successfully!";
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

                serviceResponse.ResponseData = true;
                serviceResponse.Message = "Author deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseData = true;
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<PagedList<GetCategoryResponse>> GetAsync(ResourceRequest request) 
            => await _repository.GetAsync(request);

        public async Task<ServiceResponse<GetCategoryDto>> GetByAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Author with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<GetCategoryDto>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAsync(string categoryName)
        {
            var result = await _repository.GetAsync(categoryName);

            var serviceResponse = new ServiceResponse<IEnumerable<GetCategoryDto>>();
            if (result is null)
            {
                serviceResponse.Message = $"Category with name {categoryName} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<IEnumerable<GetCategoryDto>>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCategoryDto>> UpdateAsync(UpdateCategoryDto categoryDto)
        {
            var serviceResponse = new ServiceResponse<GetCategoryDto>();

            try
            {
                var category = categoryDto.Adapt<Category>();
                var result = await _repository.UpdateAsync(category);

                serviceResponse.ResponseData = result.Adapt<GetCategoryDto>();
                serviceResponse.Message = "Category updated!";
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
