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

        public async Task<Purchase> CreateAsync(int librarianId, List<PurchaseItems> items)
        {
            try
            {
                Purchase purchase = new()
                {
                    LibrarianId = librarianId,
                    TotalPayed = items.Sum(x => x.GrossPrice),
                    PurchaseItems = items
                };

                await _context.Purchases.AddAsync(purchase);

                return purchase;
            }
            catch (Exception)
            {
                return new Purchase();
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
                                                           });

            purchasesQuery = request.SortOrder.ToLower().Equals("desc") ?
                                purchasesQuery.OrderByDescending(GetSortProperty(request.SortColumn)) :
                                purchasesQuery.OrderBy(GetSortProperty(request.SortColumn));

            int totalCount = await purchasesQuery.CountAsync();
            var purchaseList = await purchasesQuery
                                                   .Skip((request.CurrentPage - 1) * request.PageSize)
                                                   .Take(request.PageSize)
                                                   .ToListAsync();

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

        public async Task<Purchase> GetAsync(int purchaseId) 
            => await _context.Purchases
                                    .Where(prc => prc.Id == purchaseId)
                                    .Include(prc => prc.PurchaseItems)
                                    .ThenInclude(i => i.Book)
                                    .Include(prc => prc.Librarian)
                                    .FirstOrDefaultAsync();
    }
}
