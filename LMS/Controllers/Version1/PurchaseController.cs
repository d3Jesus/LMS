using LMS.Application.Interfaces;
using LMS.Application.ViewModels;
using LMS.Application.ViewModels.Purchase;
using LMS.CoreBusiness.Enums;
using LMS.CoreBusiness.Helpers;
using LMS.CoreBusiness.Requests;
using LMS.CoreBusiness.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

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

        [HttpGet("purchaseId={purchaseId}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ServiceResponse<GetPurchaseDto>))]
        public async Task<IActionResult> Get(int purchaseId)
        {
            if (purchaseId <= 0) return BadRequest("Invalid purchase ID.");

            var response = await _service.GetAsync(purchaseId);

            return response.Succeeded ? Ok(response.ResponseData) : NotFound(response.Message);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Add([FromBody] List<AddPurchaseItemsDto> items)
        {
            if (!items.Any()) return BadRequest("The shopping list can not be empty.");

            var user = HttpContext.User.Identity as ClaimsIdentity;
            if (user is null) return BadRequest("You can not register a purchase while your are not logged in. Please, log in to proceed.");

            var userClaims = user.Claims.ToList();
            var librarianId = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(librarianId) || Convert.ToInt32(librarianId) <= 0) return BadRequest("Invalid librarian ID");

            var response = await _service.AddAsync(Convert.ToInt32(librarianId), items);

            return response.Succeeded ? CreatedAtAction(nameof(Get), new { purchaseId = response.ResponseData.Id }, response.ResponseData) : BadRequest(response.Message);
        }
    }
}
