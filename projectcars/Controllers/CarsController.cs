using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Cars;
using projectcars.Models;
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

        [HttpPost("hide")]
        public async Task<IActionResult> Hide(HideCarRequest req)
        {
            try
            {
                await _carsService.Hide(req.Id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("remove")]
        public async Task<IActionResult> Remove(RemoveCarRequest req)
        {
            try
            {
                await _carsService.Remove(req.Id);
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

        [HttpGet("filtred")]
        public async Task<IActionResult> GetFiltred([FromQuery]FiltredCarsRequest req) 
        {
            try
            {
                return Ok(await _carsService.GetFiltredCars(CarFilter.Create(req.MinPrice, req.MaxPrice, req.MinEngineVolume, req.MaxEngineVolume, req.TransmissionType, req.BodyType, req.EngineType, req.DriveTrain, req.MinEnginePower, req.MaxEnginePower, req.MinMileage, req.MaxMileage, req.Color, req.Abs, req.Esp, req.Asr, req.Immobilizer, req.Signaling)));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
