using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.ViewModels;
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

        public async Task<Purchase> CreateAsync(AddPurchaseViewModel purchase)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    Purchase purchaseEntity = new()
                    {
                        LibrarianId = purchase.librarianId,
                        TotalPayed = purchase.totalPayed
                    };
                    _context.Purchases.Add(purchaseEntity);
                    _context.SaveChanges();

                    PurchaseItems purchaseItems = new()
                    {
                        PurchasedId = purchaseEntity.Id,
                        BookId = purchase.bookId,
                        NumberOfCopies = purchase.numberOfCopies,
                        BasePrice = purchase.basePrice,
                        PurchasedPrice = purchase.itemPurchasedPrice,
                        Status = "SOLD"
                    };

                    _context.Items.Add(purchaseItems);
                    await _context.SaveChangesAsync();

                    return purchaseEntity;
                }
                catch (Exception)
                {
                    return null;
                }
            }

        }

        //public async Task<Purchase> UpdateAsync(AddPurchaseViewModel purchase)
        //{
        //    _context.Entry(purchase).State = EntityState.Detached;
        //    _context.Purchases.Update(purchase);
        //    await _context.SaveChangesAsync();

        //    return purchase;
        //}
    }
}
