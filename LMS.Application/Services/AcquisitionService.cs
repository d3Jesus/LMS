using Mapster;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Acquisition;
using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Application.ViewModels;

namespace LMS.Application.Services;

public class AcquisitionService : IAcquisitionService
{
    private readonly IAcquisition _repository;

    public AcquisitionService(IAcquisition repository) => _repository = repository;

    public async Task<ServiceResponse<GetAcquisitionDto>> CreateAsync(AddAcquisitionDto acquisitionDto)
    {
        try
        {
            Acquisition acquisition = acquisitionDto.Adapt<Acquisition>();

            acquisition.Items = acquisitionDto.Items.Adapt<List<AcquisitionItems>>();
            var result = await _repository.CreateAsync(acquisition);

            if (result is null)
                return new ServiceResponse<GetAcquisitionDto>
                {
                    Succeeded = false,
                    Message = "Failed to register acquisition."
                };

            return new ServiceResponse<GetAcquisitionDto>
            {
                ResponseData = result.Adapt<GetAcquisitionDto>(),
                Succeeded = true,
                Message = "Acquisition registered successfuly."
            };
        }
        catch
        {
            return new ServiceResponse<GetAcquisitionDto>
            {
                Succeeded = false,
                Message = "An error occored while registering acquisition."
            };
        }
    }

    public async Task<ServiceResponse<List<GetAcquisitionDto>>> GetAsync(DateTime fromDate, DateTime toDate)
    {
        var response = await _repository.GetAsync(fromDate, toDate);

        return new ServiceResponse<List<GetAcquisitionDto>>
        {
            ResponseData = response.Adapt<List<GetAcquisitionDto>>(),
            Succeeded = true,
            Message = string.Empty
        };
    }

    public async Task<ServiceResponse<GetAcquisitionDto>> GetAsync(string acquisitionId)
    {
        var result = await _repository.GetAsync(acquisitionId);

        return new ServiceResponse<GetAcquisitionDto>
        {
            ResponseData = result.Adapt<GetAcquisitionDto>(),
            Succeeded = true,
            Message = string.Empty
        };
    }
}
