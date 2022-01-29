using API.Services.Catalog.Products;
using API.ViewModels.Catalog.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductServices _ProductServices;

        public ProductController(IProductServices ProductServices)
        {
            _ProductServices = ProductServices;
        }
        /// <summary>
        /// Lấy tất cả danh sách Users
        /// </summary>
        /// <returns>Danh sách Users</returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _ProductServices.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _ProductServices.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }
        [HttpDelete("Delete/{ProductId}")]
        public async Task<IActionResult> Delete(byte ProductId)
        {
            var result = await _ProductServices.Delete(ProductId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetById/{ProductId}")]
        public async Task<IActionResult> Get(byte ProductId)
        {
            var result=await _ProductServices.GetById(ProductId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetPaging")]
        public async Task<IActionResult> GetPaging([FromQuery] ProductGetPagingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result= await _ProductServices.GetPaging(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}