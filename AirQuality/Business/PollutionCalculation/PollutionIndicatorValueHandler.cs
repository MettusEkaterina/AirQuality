using AirQuality.Models;

namespace AirQuality.Business.PollutionCalculation
{
    public class PollutionIndicatorValueHandler : IPollutionIndicatorValueHandler
    {
        private readonly AirQualityLevel? _airQualityLevel;
        public double MaxValue { get; set; }

        public PollutionIndicatorValueHandler(double maxValue, AirQualityLevel airQualityLevel)
        {
            MaxValue = maxValue;
            _airQualityLevel = airQualityLevel;
        }

        public AirQualityLevel? GetAirQualityLevelOrNull(double value) =>
            MaxValue >= value ? _airQualityLevel : null;
    }
}
