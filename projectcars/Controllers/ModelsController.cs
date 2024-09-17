using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Models;
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
                await _modelsService.Create(req.ModelName, req.BrandId);

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
