using Microsoft.AspNetCore.Mvc;

namespace myapi.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Test()
    {
        return Ok("Hello World!");
    }

    [HttpPost]
    public IActionResult Echo(object body)
    {
        return Ok(body);
    }
}
