using AirQuality.Models;

namespace AirQuality.Business.PollutionCalculation
{
    public interface IPollutionIndicatorParameter
    {
        public string ParameterName { get; }
        public AirQualityLevel GetAirQualityLevel(double value);
    }
}
