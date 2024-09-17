using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Cars;
using projectcars.Services;

namespace projectcars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarsController : ControllerBase
    {
        private readonly CarsService _carsService;

        public CarsController(CarsService carsService) 
        {
            _carsService = carsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateCarRequest req) 
        {
            try 
            {
                await _carsService.Create(
                    req.Images,
                    req.Price,
                    req.EngineVolume,
                    req.TransmissionType,
                    req.BodyType,
                    req.EngineType,
                    req.DriveTrain,
                    req.EnginePower,
                    req.Mileage,
                    req.Color,
                    req.Abs,
                    req.Esp,
                    req.Asr,
                    req.Immobilazer,
                    req.Signaling,
                    req.GenerationId
                    );

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
                return Ok(await _carsService.GetActiveCars());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
