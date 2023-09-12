using LMS.Application.Interfaces;
using LMS.Application.ViewModels.Acquisition;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers.Version1
{
    [Route("api/v1/acquisitions")]
    [ApiController]
    [Authorize]
    public class AcquisitionController : ControllerBase
    {
        private readonly IAcquisitionService _service;

        public AcquisitionController(IAcquisitionService service) => _service = service;

        [HttpGet("{acquisitionId}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAcquisitionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(string acquisitionId)
        {
            if (string.IsNullOrEmpty(acquisitionId)) return BadRequest();

            var response = await _service.GetAsync(acquisitionId);

            return response?.ResponseData is null ? NotFound() : Ok(response);
        }

        [HttpGet("{fromDate}/{toDate}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GetAcquisitionDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get(DateTime fromDate, DateTime toDate)
        {
            if (toDate < fromDate) return BadRequest("The Max date(toDate) can not be lower then Min date(fromDate).");

            var response = await _service.GetAsync(fromDate, toDate);

            return response.ResponseData is null ? NotFound() : Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetAcquisitionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Add(AddAcquisitionDto acquisition)
        {
            if (acquisition is null) return BadRequest();

            var response = await _service.CreateAsync(acquisition);

            return CreatedAtAction(nameof(Get), new { response.ResponseData.Id }, response.ResponseData);
        }
    }
}
