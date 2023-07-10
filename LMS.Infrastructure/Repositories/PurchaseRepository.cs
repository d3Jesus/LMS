using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Purchase purchase, List<PurchaseItems> items)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    purchase.LibrarianId = purchase.LibrarianId;
                    purchase.TotalPayed = purchase.TotalPayed;

                    _context.Purchases.Add(purchase);
                    _context.SaveChanges();

                    foreach (var item in items)
                    {
                        PurchaseItems newPurchaseItem = new()
                        {
                            PurchaseId = purchase.Id,
                            BookId = item.BookId,
                            NumberOfCopies = item.NumberOfCopies,
                            UnitPrice = item.UnitPrice,
                            GrossPrice = item.GrossPrice
                        };
                        _context.Items.Add(newPurchaseItem);
                        await _context.SaveChangesAsync();
                    }

                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

        }

        public async Task<IEnumerable<Purchase>> GetAsync(DateTime initDate, DateTime endDate, int itemsToTake)
        {
            return await _context.Purchases
                    .Where(prc => prc.DatePurchased.Date >= initDate.Date && prc.DatePurchased.Date <= endDate.Date)
                    .Skip(0)
                    .Take(itemsToTake)
                    .OrderBy(prc => prc.DatePurchased)
                    .ToListAsync();
        }
    }
}
