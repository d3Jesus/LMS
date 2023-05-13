using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Loan;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/requests")]
    [ApiController]
    public class LoanController : ControllerBase
    {
        private readonly ILoanService _service;
        public LoanController(ILoanService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddLoanDto model)
        {
            var response = await _service.AddAsync(model);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(GetLoanDto model)
        {
            var response = await _service.UpdateAsync(model);

            return Ok(response);
        }
    }
}
