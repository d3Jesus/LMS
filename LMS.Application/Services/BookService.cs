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

        //public async Task<ServiceResponse<bool>> DeleteAsync(int id)
        //{
        //    var serviceResponse = new ServiceResponse<bool>();

        //    try
        //    {
        //        await _repository.DeleteAsync(id);

        //        serviceResponse.Message = "Book deleted successfuly!";
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.Succeeded = false;
        //        serviceResponse.Message = ex.Message;
        //    }

        //    return serviceResponse;
        //}

        //public async Task<ServiceResponse<IEnumerable<GetBookViewModel>>> GetAllAsync()
        //{
        //    var result = await _repository.GetAllAsync();

        //    var serviceResponse = new ServiceResponse<IEnumerable<GetBookViewModel>>()
        //    {
        //        ResponseData = _mapper.Map<IEnumerable<GetBookViewModel>>(result)
        //    };

        //    return serviceResponse;
        //}

        //public async Task<ServiceResponse<GetBookViewModel>> GetAllByAsync(string title)
        //{
        //    var result = await _repository.GetAllByAsync(title);

        //    var serviceResponse = new ServiceResponse<GetBookViewModel>();
        //    if (result is null)
        //    {
        //        serviceResponse.Message = $"Book with title {title} not found!";
        //        serviceResponse.Succeeded = false;
        //    }

        //    serviceResponse.ResponseData = _mapper.Map<GetBookViewModel>(result);

        //    return serviceResponse;
        //}

        //public async Task<ServiceResponse<IEnumerable<GetBookViewModel>>> GetAllByAsync(int category)
        //{
        //    var result = await _repository.GetAllByAsync(category);

        //    var serviceResponse = new ServiceResponse<IEnumerable<GetBookViewModel>>()
        //    {
        //        ResponseData = _mapper.Map<IEnumerable<GetBookViewModel>>(result)
        //    };

        //    return serviceResponse;
        //}

        //public async Task<ServiceResponse<GetBookViewModel>> GetByIdAsync(int id)
        //{
        //    var result = await _repository.GetByAsync(id);

        //    var serviceResponse = new ServiceResponse<GetBookViewModel>();
        //    if (result is null)
        //    {
        //        serviceResponse.Message = $"Book with ID {id} not found!";
        //        serviceResponse.Succeeded = false;
        //    }

        //    serviceResponse.ResponseData = _mapper.Map<GetBookViewModel>(result);

        //    return serviceResponse;
        //}

        //public async Task<ServiceResponse<GetBookViewModel>> UpdateAsync(GetBookViewModel model)
        //{
        //    var serviceResponse = new ServiceResponse<GetBookViewModel>();

        //    try
        //    {
        //        var mappedBook = _mapper.Map<Book>(model);
        //        var result = await _repository.UpdateAsync(mappedBook);

        //        serviceResponse.ResponseData = _mapper.Map<GetBookViewModel>(result);
        //        serviceResponse.Message = "Book updated!";
        //    }
        //    catch (Exception ex)
        //    {
        //        serviceResponse.Succeeded = false;
        //        serviceResponse.Message = ex.Message;
        //    }

        //    return serviceResponse;
        //}
    }
}
