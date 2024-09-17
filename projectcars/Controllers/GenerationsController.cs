using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Generations;
using projectcars.Services;

namespace projectcars.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GenerationsController : ControllerBase
    {
        private readonly GenerationsService _generationsService;

        public GenerationsController(GenerationsService generationsService) 
        {
            _generationsService = generationsService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateGenerationRequest req)
        {
            try
            {
                await _generationsService.Create(req.GenerationName, req.Restyling, req.StartYear, req.EndYear, req.ModelId, req.Image);

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
                return Ok(await _generationsService.GetGenerations());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
