using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Purchase;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers
{
    [Route("api/purchases")]
    [ApiController]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _service;
        public PurchaseController(IPurchaseService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPurchaseDto model)
        {
            var response = await _service.AddAsync(model);

            return Ok(response);
        }
    }
}
