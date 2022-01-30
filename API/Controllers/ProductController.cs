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
        private readonly IProductServices _productServices;

        public ProductController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _productServices.Create(request);
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
            var result = await _productServices.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }
        [HttpDelete("Delete/{ProductId}")]
        public async Task<IActionResult> Delete(byte ProductId)
        {
            var result = await _productServices.Delete(ProductId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetById/{ProductId}")]
        public async Task<IActionResult> Get(byte ProductId)
        {
            var result=await _productServices.GetById(ProductId);
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
            var result= await _productServices.GetPaging(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}