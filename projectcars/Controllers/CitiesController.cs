using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Cities;
using projectcars.Contracts.Regions;
using projectcars.Models;
using projectcars.Services;

namespace projectcars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CitiesController : ControllerBase
    {
        private readonly CitiesService _citiesService;

        public CitiesController(CitiesService citiesService) 
        {
            _citiesService = citiesService;
        }

        [HttpPost("create")]
        [Authorize]
        public async Task<IActionResult> Create([FromForm] CreateCityRequest req)
        {
            try
            {
                var city = City.Create(Guid.NewGuid(), req.CityName, req.RegionId);
                await _citiesService.Create(city);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove")]
        [Authorize]
        public async Task<IActionResult> Remove([FromForm] RemoveCityRequest req)
        {
            try
            {
                await _citiesService.Remove(req.CityId);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update")]
        [Authorize]
        public async Task<IActionResult> Update([FromForm] UpdateCityRequest req)
        {
            try
            {
                var city = City.Create(req.CityId, req.CityName, req.RegionId);
                await _citiesService.Update(city);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("all")]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await _citiesService.GetCities());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
