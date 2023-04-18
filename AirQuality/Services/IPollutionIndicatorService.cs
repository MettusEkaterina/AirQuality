using AirQuality.Models;

namespace AirQuality.Services
{
    public interface IPollutionIndicatorService
    {
        public AirQualityLevel GetAirQualityLevel(string parameter, double value);
    }
}
