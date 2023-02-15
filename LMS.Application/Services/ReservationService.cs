using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
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

        public async Task<ServiceResponse<GetReservationViewModel>> AddAsync(AddReservationViewModel reservation)
        {
            var serviceResponse = new ServiceResponse<GetReservationViewModel>();
            try
            {
                var mapper = _mapper.Map<Reservation>(reservation);
                var response = await _repository.AddAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetReservationViewModel>(response);
                serviceResponse.Message = $"Reservation added successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> DeleteAsync(GetReservationViewModel reservation)
        {
            var serviceResponse = new ServiceResponse<bool>();

            try
            {
                var mapper = _mapper.Map<Reservation>(reservation);
                await _repository.DeleteAsync(mapper);

                serviceResponse.Message = "Reservation deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetReservationViewModel>>> GetAsync()
        {
            var result = await _repository.GetAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<GetReservationViewModel>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetReservationViewModel>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReservationViewModel>> GetByIdAsync(int id)
        {
            var result = await _repository.GetByIdAsync(id);

            var serviceResponse = new ServiceResponse<GetReservationViewModel>();
            if (result is null)
            {
                serviceResponse.Message = $"Reservation with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetReservationViewModel>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetReservationViewModel>> UpdateAsync(GetReservationViewModel reservation)
        {
            var serviceResponse = new ServiceResponse<GetReservationViewModel>();

            try
            {
                var mappedReservation = _mapper.Map<Reservation>(reservation);
                var result = await _repository.UpdateAsync(mappedReservation);

                serviceResponse.ResponseData = _mapper.Map<GetReservationViewModel>(result);
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
