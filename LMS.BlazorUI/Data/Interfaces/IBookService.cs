﻿using LMS.BlazorUI.Data.Models;
using LMS.BlazorUI.Data.Models.ViewModels;

namespace LMS.BlazorUI.Data.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<GetBookViewModel>> GetAllAsync();
        Task<Book> GetByAsync(int id);
        Task<IEnumerable<GetBookViewModel>> GetAllByAsync(int categoryId);
        Task<ServiceResponse<Book>> CreateAsync(Book model);
        Task<ServiceResponse<Book>> UpdateAsync(Book model);
    }
}
