using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace LMS.Infrastructure.Repositories;

public class AcquisitionRepository : IAcquisitionRepository
{
    private readonly ApplicationDbContext _context;

    public AcquisitionRepository(ApplicationDbContext context) => _context = context;

    private string GenerateId()
    {
        var date = DateTimeOffset.UtcNow;
        string prefix = string.Concat("BCH-", date.Month, date.Year % 100, "-");

        if (!_context.Acquisitions.Any(bch => bch.Id.Contains(prefix)))
            return string.Concat(prefix, "0001");

        DateTime dateOfLastSale = _context.Acquisitions.Max(org => org.DateRegistered);
        string latestDocument = _context.Acquisitions
                                        .Where(dt => dt.DateRegistered.Date == dateOfLastSale.Date && dt.DateRegistered.TimeOfDay == dateOfLastSale.TimeOfDay)
                                        .OrderByDescending(sl => sl.DateRegistered)
                                        .Select(dt => dt.Id)
                                        .FirstOrDefault();

        int lengthSerie = prefix.Length;
        string tempStr = "1" + latestDocument.Remove(0, lengthSerie).ToString();
        tempStr = (Convert.ToDecimal(tempStr) + 1).ToString();

        return string.Concat(prefix, tempStr.Remove(0, 1));
    }

    public async Task<Acquisition> CreateAsync(Acquisition acquisition)
    {
        try
        {
            acquisition.Id = GenerateId();
            _context.Acquisitions.Add(acquisition);
            await _context.SaveChangesAsync();

            return acquisition;
        }
        catch (Exception ex)
        {
            Log.Error(ex, ex.InnerException.Message, ex.Message);

            return new Acquisition();
        }
    }

    public async Task<IEnumerable<Acquisition>> GetAsync(DateTime initDate, DateTime endDate)
    {
        return await _context.Acquisitions
                             .Include(bt => bt.Librarian)
                             .Include(bt => bt.Items)
                             .Where(btc => (btc.DateRegistered.Date >= initDate.Date &&
                                    btc.DateRegistered.Date <= endDate.Date))
                             .ToListAsync();
    }

    public async Task<Acquisition> GetAsync(string acquisitionId)
        => await _context.Acquisitions
                         .Where(btc => btc.Id.Equals(acquisitionId))
                         .Include(btc => btc.Items)
                         .FirstOrDefaultAsync();

}
