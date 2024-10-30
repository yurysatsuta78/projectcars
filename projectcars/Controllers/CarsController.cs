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
                var car = Car.Create(
                    Guid.NewGuid(), 
                    req.Price, 
                    req.EngineVolume, 
                    req.TransmissionType, 
                    req.BodyType, 
                    req.EngineType, 
                    req.DriveTrain, 
                    req.EnginePower, 
                    req.Mileage, 
                    req.ProdYear, 
                    req.Color,
                    req.InteriorColor,
                    req.InteriorMaterial,
                    req.Description,
                    req.CarState,
                    req.RegistrationCountry,
                    req.TowBar,
                    req.RoofRails,
                    req.SunRoof,
                    req.PanoramicRoof,
                    req.RainSensor,
                    req.RearViewCamera,
                    req.ParkingSensors,
                    req.BlindSpotSensor,
                    req.HeatedSeats,
                    req.HeatedWindshield,
                    req.HeatedMirrors,
                    req.HeatedSteeringWheel,
                    req.AutonomousHeater,
                    req.ClimateControl,
                    req.AirConditioner,
                    req.CruiseControl,
                    req.SteeringWheelMultimedia,
                    req.ElectricSeats,
                    req.FrontElectroWindows,
                    req.RearElectroWindows,
                    req.AirBags,
                    req.IsTradable,
                    req.IsRegistred,
                    req.Abs, 
                    req.Esp, 
                    req.Asr, 
                    req.Immobilizer, 
                    req.Signaling,
                    req.GenerationId,
                    req.CityId,
                    req.Images
                    );
                await _carsService.Create(car);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("hide")]
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

        [HttpDelete("remove")]
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

        [HttpGet("countactive")]
        public async Task<IActionResult> CountActiveCars() 
        {
            try
            {
                return Ok(await _carsService.CountActiveCars());
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("filtred")]
        public async Task<IActionResult> GetFiltred([FromBody]FiltredCarsRequest req) 
        {
            try
            {
                var carFilter = CarFilter.Create(
                    req.MinPrice, 
                    req.MaxPrice, 
                    req.MinEngineVolume, 
                    req.MaxEngineVolume, 
                    req.TransmissionType, 
                    req.BodyType, 
                    req.EngineType, 
                    req.DriveTrain, 
                    req.MinEnginePower, 
                    req.MaxEnginePower, 
                    req.MinMileage, 
                    req.MaxMileage, 
                    req.Color,
                    req.InteriorColor,
                    req.InteriorMaterial,
                    req.Description,
                    req.CarState,
                    req.RegistrationCountry,
                    req.TowBar,
                    req.RoofRails,
                    req.SunRoof,
                    req.PanoramicRoof,
                    req.RainSensor,
                    req.RearViewCamera,
                    req.ParkingSensors,
                    req.BlindSpotSensor,
                    req.HeatedSeats,
                    req.HeatedWindshield,
                    req.HeatedMirrors,
                    req.HeatedSteeringWheel,
                    req.AutonomousHeater,
                    req.ClimateControl,
                    req.AirConditioner,
                    req.CruiseControl,
                    req.SteeringWheelMultimedia,
                    req.ElectricSeats,
                    req.FrontElectroWindows,
                    req.RearElectroWindows,
                    req.AirBags,
                    req.IsTradable,
                    req.IsRegistred,
                    req.Abs, 
                    req.Esp, 
                    req.Asr, 
                    req.Immobilizer, 
                    req.Signaling, 
                    req.MinYear, 
                    req.MaxYear, 
                    req.GenerationId, 
                    req.ModelId, 
                    req.BrandId,
                    req.CityId
                    );
                return Ok(await _carsService.GetFiltredCars(carFilter, req.Take, req.Skip));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
