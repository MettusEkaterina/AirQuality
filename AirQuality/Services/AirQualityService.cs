using AirQuality.Models;
using AirQuality.Repositories;
using System.Globalization;

namespace AirQuality.Services
{
    public class AirQualityService : IAirQualityService
    {
        private readonly IAirQualityRepository _airQualityRepository;
        private readonly IPollutionIndicatorService _polutionIndicatorService;
        private readonly ILogger<AirQualityService> _logger;

        public AirQualityService(
            IAirQualityRepository airQualityRepository,
            IPollutionIndicatorService polutionIndicatorService,
            ILogger<AirQualityService> logger
            )
        {
            _airQualityRepository = airQualityRepository;
            _polutionIndicatorService = polutionIndicatorService;
            _logger = logger;
        }

        public async Task<AirQualityModel> LoadAirQuality(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return new AirQualityModel { City = string.Empty };
            }

            var locations = await _airQualityRepository.GetLocations(city);

            var model = new AirQualityModel
            {
                City = city,
                Locations = locations.Select(x => new AirQualityLocationModel
                {
                    City = city,
                    Country = x.Country ?? string.Empty,
                    Name = x.Name ?? city,
                    Pollutants = x.Parameters.Select(x => new PollutantModel
                    {
                        Name = x.parameter,
                        DisplayName = string.IsNullOrEmpty(x.DisplayName) ? x.parameter : x.DisplayName,
                        Unit = x.Unit,
                        Average = x.Average,
                        AirQualityLevel = GetAirQualityLevel(x.parameter, x.Average)
                    }).ToList(),
                    LastUpdated = DateTime.TryParse(x.LastUpdated, out DateTime result) ? result.ToString("dd MMMM yyyy HH:mm:ss", CultureInfo.CurrentCulture) : string.Empty
                }).ToList()
            };

            foreach (var location in model.Locations) 
            {
                AirQualityLevel levelForLocation = location.Pollutants.Max(x => x.AirQualityLevel);
                location.AirQualityLevel = levelForLocation;
                _logger.LogDebug(string.Format("Level for location {0} is {1}", location.Name, levelForLocation));
            }

            return model;
        }

        private AirQualityLevel GetAirQualityLevel(string parameter, double average) => 
            _polutionIndicatorService.GetAirQualityLevel(parameter, average);
    }
}
