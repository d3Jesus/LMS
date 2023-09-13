using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces;

public interface IAcquisitionRepository
{
    /// <summary>
    /// Register a new acquisition
    /// </summary>
    /// <param name="acquisition">Acquisition information.</param>
    /// <returns></returns>
    Task<Acquisition> CreateAsync(Acquisition acquisition);

    /// <summary>
    /// Retrieves all acquisitions in a range of date.
    /// </summary>
    /// <param name="fromDate">From date</param>
    /// <param name="toDate">To date</param>
    /// <returns>List of acquisitions in a given range of date.</returns>
    Task<IEnumerable<Acquisition>> GetAsync(DateTime fromDate, DateTime toDate);

    /// <summary>
    /// Retrieves acquisition with the given ID.
    /// </summary>
    /// <param name="acquisitionId">Acquisition ID.</param>
    /// <returns></returns>
    Task<Acquisition> GetAsync(string acquisitionId);
}
