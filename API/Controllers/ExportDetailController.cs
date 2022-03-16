using API.Services.Catalog.ExportDetails;
using API.ViewModels.Catalog.ExportDetails;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExportDetailController : ControllerBase
    {
        private readonly IExportDetailServices _ExportDetailServices;

        public ExportDetailController(IExportDetailServices ExportDetailServices)
        {
            _ExportDetailServices = ExportDetailServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ExportDetailCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _ExportDetailServices.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] ExportDetailUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _ExportDetailServices.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }
        [HttpDelete("Delete/{ExportId}&{productId}")]
        public async Task<IActionResult> Delete(int ExportId, int productId)
        {
            var result = await _ExportDetailServices.Delete(ExportId, productId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetByExportId/{ExportId}")]
        public async Task<IActionResult> GetByExportId(int ExportId)
        {
            var result = await _ExportDetailServices.GetByExportId(ExportId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetByProductId/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var result = await _ExportDetailServices.GetByProductId(productId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetPaging")]
        public async Task<IActionResult> GetPaging([FromQuery] ExportDetailGetPagingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _ExportDetailServices.GetPaging(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}
