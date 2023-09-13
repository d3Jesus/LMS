using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Enums;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Version1
{
    [ApiController]
    [Route("api/v1/purchases")]
    [Authorize]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _service;
        public PurchaseController(IPurchaseService service) => _service = service;

        [HttpGet("fromDate={fromDate}&toDate={toDate}&currentPage={currentPage}&pageSize={pageSize}&sortColumn={sortColumn}&sortOrder={sortOrder}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GetPurchaseResponse>))]
        public async Task<IActionResult> Get(DateTime fromDate,
                               DateTime toDate,
                               int currentPage,
                               int pageSize,
                               string sortColumn,
                               string sortOrder)
        {
            GetPurchaseRequest request = new(fromDate, toDate, currentPage, pageSize, sortColumn, sortOrder);
            return Ok(await _service.GetAsync(request));
        }

        [HttpGet("fromDate={fromDate}&toDate={toDate}&currentPage={currentPage}&pageSize={pageSize}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedList<GetPurchaseResponse>))]
        public async Task<IActionResult> Get(DateTime fromDate,
                               DateTime toDate,
                               int currentPage,
                               int pageSize)
        {
            GetPurchaseRequest request = new(fromDate, toDate, currentPage, pageSize, SortColumn: "id", ColumnSortOrder.desc.ToString());
            return Ok(await _service.GetAsync(request));
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddPurchaseDto model)
        {
            var response = await _service.AddAsync(model);

            return Ok(response);
        }
    }
}
