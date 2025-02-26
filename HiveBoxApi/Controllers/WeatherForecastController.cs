using Microsoft.AspNetCore.Mvc;
using HiveBoxApi.Services;
namespace HiveBoxApi.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IConfiguration configuration;
    private readonly IAppVersionService appVersionService;

    public WeatherForecastController(ILogger<WeatherForecastController> logger,
    IConfiguration configuration,
    IAppVersionService appVersionService)
    {
        _logger = logger;
        this.configuration = configuration;
        this.appVersionService = appVersionService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    [HttpGet("[action]")]
    public IActionResult AppVersion()
    {
        return Ok(appVersionService.GetAppVersion());
    }
}
