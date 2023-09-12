
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Acquisition;

namespace LMS.Application.Interfaces;

public interface IAcquisitionService
{
    /// <summary>
    /// Register a new acquisition
    /// </summary>
    /// <param name="acquisitionDto">Acquisition information.</param>
    /// <returns></returns>
    Task<ServiceResponse<GetAcquisitionDto>> CreateAsync(AddAcquisitionDto acquisitionDto);

    /// <summary>
    /// Retrieves all acquisitions in a range of date.
    /// </summary>
    /// <param name="fromDate">From date</param>
    /// <param name="toDate">To date</param>
    /// <returns>List of acquisitions in a given range of date.</returns>
    Task<ServiceResponse<List<GetAcquisitionDto>>> GetAsync(DateTime fromDate, DateTime toDate);

    /// <summary>
    /// Retrieves acquisition with the given ID.
    /// </summary>
    /// <param name="acquisitionId">Acquisition ID.</param>
    /// <returns></returns>
    Task<ServiceResponse<GetAcquisitionDto>> GetAsync(string acquisitionId);
}
