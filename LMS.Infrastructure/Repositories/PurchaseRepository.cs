using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace LMS.Infrastructure.Repositories
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private readonly ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context) => _context = context;

        public async Task<bool> CreateAsync(Purchase purchase, List<PurchaseItems> items)
        {
            using var transaction = _context.Database.BeginTransaction();

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

        public async Task<PagedList<GetPurchaseResponse>> GetAsync(GetPurchaseRequest request)
        {
            IQueryable<GetPurchaseResponse> purchasesQuery = _context.Purchases
                                                          .Where(prc => prc.DatePurchased.Date >= request.FromDate.Date &&
                                                                prc.DatePurchased.Date <= request.ToDate.Date)
                                                           .Select(x => new GetPurchaseResponse()
                                                           {
                                                               Id = x.Id,
                                                               LibrarianId = x.LibrarianId,
                                                               DatePurchased = x.DatePurchased,
                                                               TotalPayed = x.TotalPayed
                                                           })
                                                          .Skip((request.CurrentPage - 1) * request.PageSize)
                                                          .Take(request.PageSize);

            purchasesQuery = request.SortOrder.ToLower().Equals("desc") ?
                                purchasesQuery.OrderByDescending(GetSortProperty(request.SortColumn)) :
                                purchasesQuery.OrderBy(GetSortProperty(request.SortColumn));

            int totalCount = await purchasesQuery.CountAsync();
            var purchaseList = await purchasesQuery.ToListAsync();

            var purchasesPaged = PagedList<GetPurchaseResponse>.CreateAsync(purchaseList,
                                                                  request.CurrentPage,
                                                                  request.PageSize,
                                                                  totalCount);
            
            return purchasesPaged;
        }

        private static Expression<Func<GetPurchaseResponse, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "date" => purchase => purchase.DatePurchased,
                "amout" => purchase => purchase.TotalPayed,
                _ => purchase => purchase.Id
            };
        }
    }
}
