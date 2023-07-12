using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Author;
using LMS.Application.ViewModels.UserAccount;
using LMS.CoreBusiness.Entities.Accounts;
using LMS.CoreBusiness.Interfaces;

namespace LMS.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IMapper _mapper;

        public AccountService(IAccountRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<IEnumerable<RolesDto>>> GetRoles()
        {
            var result = await _repository.GetRolesAsync();

            var serviceResponse = new ServiceResponse<IEnumerable<RolesDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<RolesDto>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<bool>> Register(UserRegistrationDto model)
        {
            var serviceResponse = new ServiceResponse<bool>();
            try
            {
                UserRegistration newUser = _mapper.Map<UserRegistration>(model);
                var response = await _repository.Register(newUser);

                serviceResponse.ResponseData = response;
                serviceResponse.Message = $"User created successfully!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }
        public async Task<ServiceResponse<string>> Login(UserLoginDto model)
        {
            var serviceResponse = new ServiceResponse<string>();
            try
            {
                UserLogin loggin = _mapper.Map<UserLogin>(model);
                var response = await _repository.Login(loggin);

                serviceResponse.ResponseData = response;
                serviceResponse.Message = $"User logged in successfully!";
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
