using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using System.Xml.Linq;

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

        public async Task<ServiceResponse<GetAuthorViewModel>> AddAsync(AddAuthorViewModel author)
        {
            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();
            try
            {
                var mapper = _mapper.Map<Author>(author);
                var response = await _repository.AddAsync(mapper);
                
                serviceResponse.ResponseData = _mapper.Map<GetAuthorViewModel>(response);
            }
            catch(Exception ex) 
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetAuthorViewModel author)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Author>(author);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Author deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetAuthorViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetAuthorViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetAuthorViewModel>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Author with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetAuthorViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorViewModel>> GetByNameAsync(string name)
        {
            var result = await _repository.GetByNameAsync(name);

            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Author with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetAuthorViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorViewModel>> GetByNationalityAsync(string nationality)
        {
            var result = await _repository.GetByNationalityAsync(nationality);

            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Author with nationality {nationality} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetAuthorViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAuthorViewModel>> UpdateAsync(GetAuthorViewModel author)
        {
            var serviceResponse = new ServiceResponse<GetAuthorViewModel>();

            try
            {
                var mappedAuthor = _mapper.Map<Author>(author);
                var result = await _repository.UpdateAsync(mappedAuthor);

                serviceResponse.ResponseData = _mapper.Map<GetAuthorViewModel>(result);
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
