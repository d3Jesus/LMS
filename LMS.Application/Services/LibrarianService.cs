using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Librarian;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using Mapster;

namespace LMS.Application.Services
{
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository _repository;

        public LibrarianService(ILibrarianRepository repository) => _repository = repository;

        public async Task<ServiceResponse<GetLibrarianDto>> CreateAsync(AddLibrarianDto librarian)
        {
            var serviceResponse = new ServiceResponse<GetLibrarianDto>();
            try
            {
                var mapper = librarian.Adapt<Librarian>();
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = response.Adapt<GetLibrarianDto>();
                serviceResponse.Message = $"Librarian with name {string.Concat(librarian.FirstName, " ", librarian.LastName)} added successfully!";
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
                serviceResponse.ResponseData = await _repository.DeleteAsync(id);

                serviceResponse.Message = "Librarian deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.ResponseData = false;
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetLibrarianDto>>> GetAsync(bool wasDeleted)
        {
            var result = await _repository.GetAsync(wasDeleted);

            var serviceResponse = new ServiceResponse<IEnumerable<GetLibrarianDto>>()
            {
                ResponseData = result.Adapt<IEnumerable<GetLibrarianDto>>()
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianDto>> GetByAsync(int id)
        {
            var result = await _repository.GetAsync(id);

            var serviceResponse = new ServiceResponse<GetLibrarianDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Librarian with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<GetLibrarianDto>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianDto>> GetByAsync(string name)
        {
            var result = await _repository.GetAsync(name);

            var serviceResponse = new ServiceResponse<GetLibrarianDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Librarian with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = result.Adapt<GetLibrarianDto>();

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetLibrarianDto>> UpdateAsync(UpdateLibrarianDto librarian)
        {
            var serviceResponse = new ServiceResponse<GetLibrarianDto>();

            try
            {
                var mappedLibrarian = librarian.Adapt<Librarian>();
                var result = await _repository.UpdateAsync(mappedLibrarian);

                serviceResponse.ResponseData = result.Adapt<GetLibrarianDto>();
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
