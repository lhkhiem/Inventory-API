using API.Services.Catalog.ImportDetails;
using API.ViewModels.Catalog.ImportDetails;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImportDetailController : ControllerBase
    {
        private readonly IImportDetailServices _importDetailServices;

        public ImportDetailController(IImportDetailServices importDetailServices)
        {
            _importDetailServices = importDetailServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ImportDetailCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _importDetailServices.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] ImportDetailUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _importDetailServices.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }
        [HttpDelete("Delete/{importId}&{productId}")]
        public async Task<IActionResult> Delete(int importId, int productId)
        {
            var result = await _importDetailServices.Delete(importId, productId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetByImportId/{importId}")]
        public async Task<IActionResult> GetByImportId(int importId)
        {
            var result = await _importDetailServices.GetByImportId(importId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetByProductId/{productId}")]
        public async Task<IActionResult> GetByProductId(int productId)
        {
            var result = await _importDetailServices.GetByProductId(productId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetPaging")]
        public async Task<IActionResult> GetPaging([FromQuery] ImportDetailGetPagingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _importDetailServices.GetPaging(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}
