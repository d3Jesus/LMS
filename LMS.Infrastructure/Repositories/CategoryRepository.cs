﻿using LMS.CoreBusiness.Entities;
using LMS.CoreBusiness.Interfaces;
using LMS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LMS.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var existingCategory = _context.Categories.Where(cat => cat.Id == id).FirstOrDefault();

            _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public Category GetBy(int id)
        {
            return _context.Categories.Find(id);
        }

        public async Task<IEnumerable<Category>> GetAsync(string categoryName)
        {
            return await _context.Categories.Where(cat => cat.CategoryName.Equals(categoryName, StringComparison.OrdinalIgnoreCase)).ToListAsync();
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<Category> GetByAsync(int id)
        {
            return await _context.Categories
                        .Where(cat => cat.Id == id)
                        .FirstOrDefaultAsync();
        }
    }
}
