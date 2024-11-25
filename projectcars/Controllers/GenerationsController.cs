using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using projectcars.Contracts.Brands;
using projectcars.Contracts.Generations;
using projectcars.Models;
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
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Create([FromForm] CreateGenerationRequest req)
        {
            try
            {
                var generation = Generation.Create(Guid.NewGuid(), req.GenerationName, req.Restyling, req.StartYear, req.EndYear, req.ModelId, req.Image);
                await _generationsService.Create(generation);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("remove")]
        [Authorize(Policy = "RequireAdminRole")]
        public async Task<IActionResult> Remove([FromForm] RemoveGenerationRequest req)
        {
            try
            {
                await _generationsService.Remove(req.GenerationId);

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
