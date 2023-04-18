using Microsoft.AspNetCore.Mvc;
using AirQuality.Services;

namespace AirQuality.Controllers;

public class AirQualityController : Controller
{
    private readonly IAirQualityService _airQualityService;

    public AirQualityController(IAirQualityService airQualityService)
    {
        _airQualityService = airQualityService;
    }

    public async Task<IActionResult> Index()
    {
        var result = await _airQualityService.LoadAirQuality("London");

        return View(result);
    }

    [HttpPost]
    public async Task<IActionResult> Index(string? city)
    {
        var result = await _airQualityService.LoadAirQuality(city ?? string.Empty);

        return View(result);
    }
}