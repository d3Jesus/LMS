using AutoMapper;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Reader;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using System.Reflection.PortableExecutable;

namespace LMS.Application.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _repository;
        private readonly IMapper _mapper;

        public MemberService(IMapper mapper, IMemberRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ServiceResponse<GetMemberDto>> CreateAsync(AddMemberDto member)
        {
            var serviceResponse = new ServiceResponse<GetMemberDto>();
            try
            {
                var mapper = _mapper.Map<Member>(member);
                var response = await _repository.CreateAsync(mapper);

                serviceResponse.ResponseData = _mapper.Map<GetMemberDto>(response);
                serviceResponse.Message = $"Member with name {string.Concat(member.firstName, " ", member.lastName)} added successfully!";
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

                serviceResponse.Message = "Member deleted successfuly!";
            }
            catch (Exception ex)
            {
                serviceResponse.Succeeded = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<IEnumerable<GetMemberDto>>> GetAsync(bool wasDeleted)
        {
            var result = await _repository.GetAsync(wasDeleted);

            var serviceResponse = new ServiceResponse<IEnumerable<GetMemberDto>>()
            {
                ResponseData = _mapper.Map<IEnumerable<GetMemberDto>>(result)
            };

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMemberDto>> GetByAsync(int id)
        {
            var result = await _repository.GetByAsync(id);

            var serviceResponse = new ServiceResponse<GetMemberDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Reader with ID {id} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetMemberDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMemberDto>> GetByAsync(string name)
        {
            var result = await _repository.GetByAsync(name);

            var serviceResponse = new ServiceResponse<GetMemberDto>();
            if (result is null)
            {
                serviceResponse.Message = $"Reader with name {name} not found!";
                serviceResponse.Succeeded = false;
            }

            serviceResponse.ResponseData = _mapper.Map<GetMemberDto>(result);

            return serviceResponse;
        }

        public async Task<ServiceResponse<GetMemberDto>> UpdateAsync(GetMemberDto member)
        {
            var serviceResponse = new ServiceResponse<GetMemberDto>();

            try
            {
                var mappedReader = _mapper.Map<Member>(member);
                var result = await _repository.UpdateAsync(mappedReader);

                serviceResponse.ResponseData = _mapper.Map<GetMemberDto>(result);
                serviceResponse.Message = "Reader updated!";
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
