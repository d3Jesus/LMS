using Mapster;
using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Acquisition;
using LMS.CoreBusiness.Entities;
using LMS.Application.ViewModels;
using LMS.CoreBusiness.UnitsOfWork;

namespace LMS.Application.Services;

public class AcquisitionService : IAcquisitionService
{
    private readonly IAcquisitionUnitOfWork _unitOfWork;

    public AcquisitionService(IAcquisitionUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<ServiceResponse<GetAcquisitionDto>> CreateAsync(AddAcquisitionDto acquisitionDto)
    {
        try
        {
            _unitOfWork.BeginTransaction();

            Acquisition acquisition = acquisitionDto.Adapt<Acquisition>();
            acquisition.Items = acquisitionDto.Items.Adapt<List<AcquisitionItems>>();

            var result = await _unitOfWork.AcquisitionRepository.CreateAsync(acquisition);

            foreach(var item in acquisition.Items) 
            {
                Stock stock = new()
                {
                    BookId = item.BookId,
                    NumberOfCopies = item.Quantity,
                    SalePrice = item.SalePrice
                };

                await _unitOfWork.StockRepository.AddOrUpdateAsync(stock);
            }

            if (_unitOfWork.CommitTransaction())
                return new ServiceResponse<GetAcquisitionDto>
                {
                    ResponseData = result.Adapt<GetAcquisitionDto>(),
                    Succeeded = true,
                    Message = "Acquisition registered successfuly."
                };

            return new ServiceResponse<GetAcquisitionDto>
            {
                Succeeded = false,
                Message = "Failed to register acquisition."
            };
        }
        catch
        {
            _unitOfWork.RollbackTransaction();
            return new ServiceResponse<GetAcquisitionDto>
            {
                Succeeded = false,
                Message = "An error occored while registering acquisition."
            };
        }
    }

    public async Task<ServiceResponse<List<GetAcquisitionDto>>> GetAsync(DateTime fromDate, DateTime toDate)
    {
        var response = await _unitOfWork.AcquisitionRepository.GetAsync(fromDate, toDate);

        return new ServiceResponse<List<GetAcquisitionDto>>
        {
            ResponseData = response.Adapt<List<GetAcquisitionDto>>(),
            Succeeded = true,
            Message = string.Empty
        };
    }

    public async Task<ServiceResponse<GetAcquisitionDto>> GetAsync(string acquisitionId)
    {
        var result = await _unitOfWork.AcquisitionRepository.GetAsync(acquisitionId);

        return new ServiceResponse<GetAcquisitionDto>
        {
            ResponseData = result.Adapt<GetAcquisitionDto>(),
            Succeeded = true,
            Message = string.Empty
        };
    }
}
