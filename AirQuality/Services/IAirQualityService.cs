using AirQuality.Models;

namespace AirQuality.Services
{
    public interface IAirQualityService
    {
        public Task<AirQualityModel> LoadAirQuality(string city);
    }
}
