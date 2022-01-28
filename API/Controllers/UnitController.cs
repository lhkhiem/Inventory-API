using API.Services.Catalog.Units;
using API.ViewModels.Catalog.Units;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        private readonly IUnitServices _unitServices;

        public UnitController(IUnitServices unitServices)
        {
            _unitServices = unitServices;
        }
        /// <summary>
        /// Lấy tất cả danh sách Users
        /// </summary>
        /// <returns>Danh sách Users</returns>
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromForm] UnitCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _unitServices.Create(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromForm] UnitUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _unitServices.Update(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);

        }
        [HttpDelete("Delete/{unitId}")]
        public async Task<IActionResult> Delete(byte unitId)
        {
            var result = await _unitServices.Delete(unitId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetById/{unitId}")]
        public async Task<IActionResult> Get(byte unitId)
        {
            var result=await _unitServices.GetById(unitId);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
        [HttpGet("GetPaging")]
        public async Task<IActionResult> GetPaging([FromQuery] UnitGetPagingRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result= await _unitServices.GetPaging(request);
            if (!result.IsSuccessed) return BadRequest(result);
            return Ok(result);
        }
    }
}