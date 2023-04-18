using AirQuality.Models;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace AirQuality.Business.Extensions
{
    public static class AirQualityLevelExtensions
    {
        public static string GetDisplayName(this AirQualityLevel airQualityLevel)
        {
            return ConfigurationManager.AppSettings[airQualityLevel.ToString()] != null ? ConfigurationManager.AppSettings[airQualityLevel.ToString()] : string.Empty;
        }
    }
}
