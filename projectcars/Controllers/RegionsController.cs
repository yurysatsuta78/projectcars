using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Brands;
using projectcars.Contracts.Regions;
using projectcars.Models;
using projectcars.Services;

namespace projectcars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : ControllerBase
    {
        private readonly RegionsService _regionsService;

        public RegionsController(RegionsService regionsService) 
        {
            _regionsService = regionsService;
        }

        [HttpPost("create")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Create([FromForm] CreateRegionRequest req)
        {
            try
            {
                var region = Region.Create(Guid.NewGuid(), req.RegionName);
                await _regionsService.Create(region);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Remove([FromForm] RemoveRegionRequest req)
        {
            try
            {
                await _regionsService.Remove(req.RegionId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Update([FromForm] UpdateRegionRequest req) 
        {
            try
            {
                var region = Region.Create(req.RegionId, req.RegionName);
                await _regionsService.Update(region);

                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _regionsService.GetRegions());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
