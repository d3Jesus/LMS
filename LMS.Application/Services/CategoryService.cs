using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Category;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, ICategoryRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetCategoryDto>> CreateAsync(AddCategoryDto category)
        {
            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            try
            {
                var mapper = _mapper.Map<Category>(category);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetCategoryDto>(response);
                serviceResponse.Message = $"Author with name {category.name} added successfully!";
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

        public async Task<ServiceResponse<IEnumerable<GetCategoryDto>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetCategoryDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetCategoryDto>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCategoryDto>> GetByAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetCategoryDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Author with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetCategoryDto>(result);

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

            serviceResponse.ResponseData = _mapper.Map<IEnumerable<GetCategoryDto>>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCategoryDto>> UpdateAsync(GetCategoryDto category)
        {
            var serviceResponse = new ServiceResponse<GetCategoryDto>();

            try
            {
                var mapper = _mapper.Map<Category>(category);
                var result = await _repository.UpdateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetCategoryDto>(result);
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
