using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Interfaces;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using LMS.CoreBusiness.Responses.Book;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Linq.Expressions;

namespace LMS.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) => _context = context;

        public async Task<Category> CreateAsync(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();

                return category;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);
                return new Category();
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var existingCategory = _context.Categories.Where(cat => cat.Id == id).FirstOrDefault();

                _context.Categories.Remove(existingCategory);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);
                return false;
            }
        }

        public async Task<PagedList<GetCategoryResponse>> GetAsync(ResourceRequest request)
        {
            IQueryable<GetCategoryResponse> categoriesQuery = _context.Categories
                                                           .Where(cat => cat.CategoryName.Contains(request.SearchTerm))
                                                           .Select(cat => new GetCategoryResponse()
                                                           {
                                                               Id = cat.Id,
                                                               CategoryName = cat.CategoryName
                                                           });

            categoriesQuery = request.SortOrder.ToLower().Equals("desc") ?
                                categoriesQuery.OrderByDescending(GetSortProperty(request.SortColumn)) :
                                categoriesQuery.OrderBy(GetSortProperty(request.SortColumn));

            int totalCount = await categoriesQuery.CountAsync();
            var categoriesList = await categoriesQuery
                                                .Skip((request.CurrentPage - 1) * request.PageSize)
                                                .Take(request.PageSize).ToListAsync();

            var categoriesPaged = PagedList<GetCategoryResponse>.CreateAsync(categoriesList,
                                                                  request.CurrentPage,
                                                                  request.PageSize,
                                                                  totalCount);

            return categoriesPaged;
        }

        public async Task<IEnumerable<Category>> GetAsync(string categoryName) 
            => await _context.Categories.Where(cat => cat.CategoryName.Equals(categoryName)).AsNoTracking().ToListAsync();

        public async Task<Category> UpdateAsync(Category category)
        {
            try
            {
                Category existingCategory = await GetByAsync(category.Id);
                if (existingCategory is null) return category;

                existingCategory.CategoryName = category.CategoryName;

                _context.Entry(existingCategory).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return category;
            }
            catch (Exception ex)
            {
                Log.Error(ex, ex.InnerException.Message, ex.Message);
                return new Category();
            }
        }

        public async Task<Category> GetByAsync(int id) 
            => await _context.Categories
                        .Where(cat => cat.Id == id)
                        .AsNoTracking()
                        .FirstOrDefaultAsync();


        private static Expression<Func<GetCategoryResponse, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn.ToLower() switch
            {
                "name" => author => author.CategoryName,
                _ => author => author.Id
            };
        }
    }
}
