using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;
using LMS.Application.ViewModels.Reservation;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IReservationRepository _repository;
        private readonly IMapper _mapper;

        public ReservationService(IMapper mapper, IReservationRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetReservationDto>> CreateAsync(AddReservationDto reservation)
        {
            var serviceResponse = new ServiceResponse<GetReservationDto>();
            try
            {
                var mapper = _mapper.Map<Reservation>(reservation);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetReservationDto>(response);
                serviceResponse.Message = $"Reservation added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetReservationDto>>> GetAllAsync()
        {
            var result = await _repository.GetAllAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetReservationDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetReservationDto>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReservationDto>> GetByAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetReservationDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Reservation with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetReservationDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReservationDto>> UpdateAsync(GetReservationDto reservation)
        {
            var serviceResponse = new ServiceResponse<GetReservationDto>();

            try
            {
                var mappedReservation = _mapper.Map<Reservation>(reservation);
                var result = await _repository.UpdateAsync(mappedReservation);

                serviceResponse.ResponseData = _mapper.Map<GetReservationDto>(result);
                serviceResponse.Message = "Reservation updated!";
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
