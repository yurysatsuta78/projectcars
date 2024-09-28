using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Brands;
using projectcars.Contracts.Cars;
using projectcars.Services;

namespace projectcars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BrandsController : ControllerBase
    {
        private readonly BrandsService _brandsService;

        public BrandsController(BrandsService brandsService)
        {
            _brandsService = brandsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateBrandRequest req)
        {
            try
            {
                await _brandsService.Create(req.BrandName, req.Image);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove([FromForm] RemoveBrandRequest req)
        {
            try
            {
                await _brandsService.Remove(req.BrandId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll() 
        {
            try 
            {
                return Ok(await _brandsService.GetBrands());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
