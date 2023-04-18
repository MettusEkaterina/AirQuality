using AirQuality.Business.PollutionCalculation;
using AirQuality.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace AirQuality.Services
{
    public class PollutionIndicatorService : IPollutionIndicatorService
    {
        private readonly List<IPollutionIndicatorParameter> parameters;
        private readonly ILogger<IPollutionIndicatorService> _logger;

        public PollutionIndicatorService(ILogger<IPollutionIndicatorService> logger) 
        {
            _logger = logger;

            var parameterNames = ConfigurationManager.AppSettings["parameters"]?.Split(",") ?? Array.Empty<string>();
            parameters = new List<IPollutionIndicatorParameter>();
            _logger.LogInformation(string.Format("Retrieved parameters {0} from config", parameterNames));

            foreach (var parameterName in parameterNames)
            {
                var handlers = new List<IPollutionIndicatorValueHandler>();

                foreach (AirQualityLevel level in Enum.GetValues(typeof(AirQualityLevel)))
                {
                    if (level == AirQualityLevel.Unknown || level == AirQualityLevel.Hazardous)
                    {
                        continue;
                    }

                    var key = string.Format("{0}:{1}:max", parameterName, level);
                    if (ConfigurationManager.AppSettings[key] != null)
                    {
                        var isParsed = double.TryParse(ConfigurationManager.AppSettings[key], out double max);

                        if (isParsed)
                        {
                            handlers.Add(new PollutionIndicatorValueHandler(max, level));
                        }

                        _logger.LogInformation(string.Format("Max value for parameter {0} with level {1} is {2}", parameterName, level, max));
                    }                            
                }
                parameters.Add(new PollutionIndicatorParameter(parameterName, handlers));
            }
        }

        public AirQualityLevel GetAirQualityLevel(string parameter, double value)
        {
            IPollutionIndicatorParameter? pollutionParameter = parameters.FirstOrDefault(x => x.ParameterName == parameter);
            return pollutionParameter == null ? AirQualityLevel.Unknown : pollutionParameter.GetAirQualityLevel(value);
        }
    }
}
