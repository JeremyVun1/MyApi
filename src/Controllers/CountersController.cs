using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CountersController : ControllerBase
{
    private readonly ICounterService _counterService;

    public CountersController(ICounterService counterService)
    {
        _counterService = counterService;
    }

    [HttpGet]
    [Route("{counterId}")]
    public async Task<IActionResult> GetCounter([FromQuery] int counterId)
    {
        if (counterId <= 0)
        {
            return BadRequest();
        }
        else
        {
            return Ok(await _counterService.GetCounter(counterId));
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetCounters()
    {
        return Ok(await _counterService.GetCounters());
    }

    [HttpPost]
    [Route("{counterId}")]
    public async Task<IActionResult> ChangeCount(int counterId, [FromBody]Counter amount)
    {
        if (counterId <= 0)
        {
            return BadRequest();
        }
        else
        {
            var request = new Counter
            {
                Id = counterId,
                Value = amount.Value
            };

            await _counterService.ChangeCount(request);

            return Ok();
        }
    }

    [HttpDelete]
    [Route("{counterId}")]
    public async Task<IActionResult> DeleteCounter(int counterId)
    {
        if (counterId <= 0)
        {
            return BadRequest();
        }
        else
        {
            await _counterService.DeleteCounter(counterId);
            return Ok();
        }
    }

    [HttpPost]
    [Route("new")]
    public async Task<IActionResult> CreateCounter()
    {
        await _counterService.CreateCounter();
        return Ok();
    }
}