using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IMapper mapper, IAuthorRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetAuthorDto>> CreateAsync(AddAuthorDto author)
        {
            var serviceResponse = new ServiceResponse<GetAuthorDto>();
            try
            {
                var mapper = _mapper.Map<Author>(author);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetAuthorDto>(response);
                serviceResponse.Message = $"Author with name {string.Concat(author.firstName, " ", author.lastName)} added successfully!";
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
                ResponseData = _mapper.Map<IEnumerable<GetAuthorDto>>(result)
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

            serviceResponse.ResponseData = _mapper.Map<GetAuthorDto>(result);

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

            serviceResponse.ResponseData = _mapper.Map<IEnumerable<GetAuthorDto>>(result);

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

            serviceResponse.ResponseData = _mapper.Map<GetAuthorDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorDto>> UpdateAsync(GetAuthorDto author)
        {
            var serviceResponse = new ServiceResponse<GetAuthorDto>();

            try
            {
                var mappedAuthor = _mapper.Map<Author>(author);
                var result = await _repository.UpdateAsync(mappedAuthor);

                serviceResponse.ResponseData = _mapper.Map<GetAuthorDto>(result);
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
