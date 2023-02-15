using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Librarian;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository _repository;
        private readonly IMapper _mapper;

        public LibrarianService(IMapper mapper, ILibrarianRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetLibrarianViewModel>> AddAsync(AddLibrarianViewModel librarian)
        {
            var serviceResponse = new ServiceResponse<GetLibrarianViewModel>();
            try
            {
                var mapper = _mapper.Map<Librarian>(librarian);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetLibrarianViewModel>(response);
                serviceResponse.Message = $"Librarian with name {string.Concat(librarian.FirstName, librarian.LastName)} added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetLibrarianViewModel librarian)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Librarian>(librarian);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Librarian deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetLibrarianViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetLibrarianViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetLibrarianViewModel>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetLibrarianViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Librarian with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetLibrarianViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianViewModel>> GetByNameAsync(string name)
        {
            var result = await _repository.GetByNameAsync(name);

            var serviceResponse = new ServiceResponse<GetLibrarianViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Librarian with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetLibrarianViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianViewModel>> UpdateAsync(GetLibrarianViewModel librarian)
        {
            var serviceResponse = new ServiceResponse<GetLibrarianViewModel>();

            try
            {
                var mappedLibrarian = _mapper.Map<Librarian>(librarian);
                var result = await _repository.UpdateAsync(mappedLibrarian);

                serviceResponse.ResponseData = _mapper.Map<GetLibrarianViewModel>(result);
                serviceResponse.Message = "Librarian updated!";
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
