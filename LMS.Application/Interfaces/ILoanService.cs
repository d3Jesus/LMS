﻿using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Request;

namespace LMS.Application.Interfaces
{
    public interface ILoanService
    {
        Task<ServiceResponse<GetLoanDto>> AddAsync(AddLoanDto loan);
        Task<ServiceResponse<GetLoanDto>> UpdateAsync(GetLoanDto loan);
    }
}
