using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using projectcars.Contracts.Cars;
using projectcars.Contracts.Models;
using projectcars.Models;
using projectcars.Services;

namespace projectcars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModelsController : ControllerBase
    {
        private readonly ModelsService _modelsService;

        public ModelsController(ModelsService modelsService) 
        {
            _modelsService = modelsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateModelRequest req)
        {
            try
            {
                var model = Model.Create(Guid.NewGuid(), req.ModelName, req.BrandId);
                await _modelsService.Create(model);

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
                await _modelsService.Remove(req.Id);
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
                return Ok(await _modelsService.GetModels());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
