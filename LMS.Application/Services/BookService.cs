using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Book;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.ViewModels;

namespace LMS.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IMapper mapper, IBookRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetBookDto>> CreateAsync(AddBookDto model)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            try
            {
                var book = _mapper.Map<AddBookViewModel>(model);
                var response = await _repository.CreateAsync(book);

                if (response is not null)
                {
                    serviceResponse.ResponseData = _mapper.Map<GetBookDto>(response);
                    serviceResponse.Message = "Book added successfully!";
                }
                else
                    serviceResponse.Message = "An error occored while saving the record!";
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

                serviceResponse.Message = "Book deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetAllBooksDto>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetAllBooksDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetAllBooksDto>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetAllBooksDto>>> GetAllByAsync(string title)
        {
            var result = await _repository.GetAllByAsync(title);

            var serviceResponse = new ServiceResponse<IEnumerable<GetAllBooksDto>>();
            if (result is null)
            {
                serviceResponse.Message = $"Book with title {title} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<IEnumerable<GetAllBooksDto>>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetBookDto>>> GetAllByAsync(int category)
        {
            var result = await _repository.GetAllByAsync(category);

            var serviceResponse = new ServiceResponse<IEnumerable<GetBookDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetBookDto>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetAllBooksDto>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetAllBooksDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Book with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetAllBooksDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetBookDto>> UpdateAsync(UpdateBookDto model)
        {
            var serviceResponse = new ServiceResponse<GetBookDto>();
            try
            {
                var book = _mapper.Map<UpdateBookViewModel>(model);
                var response = await _repository.UpdateAsync(book);

                if (response is not null)
                {
                    serviceResponse.ResponseData = _mapper.Map<GetBookDto>(response);
                    serviceResponse.Message = "Book updated!";
                }
                else
                    serviceResponse.Message = "An error occored while updating the record!";
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
