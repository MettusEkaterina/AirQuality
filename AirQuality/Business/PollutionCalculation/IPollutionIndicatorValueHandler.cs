using AirQuality.Models;

namespace AirQuality.Business.PollutionCalculation
{
    public interface IPollutionIndicatorValueHandler
    {
        public double MaxValue { get; set; }

        public AirQualityLevel? GetAirQualityLevelOrNull(double value);
    }
}
