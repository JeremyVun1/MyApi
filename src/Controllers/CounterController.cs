using Microsoft.AspNetCore.Mvc;
using MyApi.Models;
using MyApi.Services;

namespace MyApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CounterController : ControllerBase
{
    private readonly ICounterService _counterService;

    public CounterController(ICounterService counterService)
    {
        _counterService = counterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCount()
    {
        return Ok(await _counterService.GetCount());
    }

    [HttpPost]
    public async Task<IActionResult> ChangeCount([FromBody] ChangeCountRequest request)
    {
        await _counterService.ChangeCount(request.Value);

        return Ok();
    }
}