using AirQuality.Models;

namespace AirQuality.Business.PollutionCalculation
{
    public class PollutionIndicatorParameter : IPollutionIndicatorParameter
    {
        private readonly List<IPollutionIndicatorValueHandler> _valueHandlers;

        public string ParameterName { get; }

        public PollutionIndicatorParameter(string parameterName, List<IPollutionIndicatorValueHandler> valueHandlers)
        {
            _valueHandlers = valueHandlers.OrderBy(x => x.MaxValue).ToList();
            ParameterName = parameterName;
        }

        public AirQualityLevel GetAirQualityLevel(double value)
        {
            AirQualityLevel? level = _valueHandlers?.FirstOrDefault(valueHandler => valueHandler.GetAirQualityLevelOrNull(value) != null)?.GetAirQualityLevelOrNull(value);
            return level == null ? AirQualityLevel.Hazardous : (AirQualityLevel)level;
        }
    }
}
