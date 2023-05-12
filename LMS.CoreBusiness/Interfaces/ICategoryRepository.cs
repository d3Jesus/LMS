﻿using LMS.CoreBusiness.Entities;

namespace LMS.CoreBusiness.Interfaces
{
    public interface ICategoryRepository
    {
        Task<Category> CreateAsync(Category category);
        Task<Category> UpdateAsync(Category category);
        Task<bool> DeleteAsync(int id);
        Task<Category> GetAsync(int id);
        Task<IEnumerable<Category>> GetAsync(string categoryName);
    }
}
