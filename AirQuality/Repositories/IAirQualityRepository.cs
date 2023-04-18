using AirQuality.Models.Requests;

namespace AirQuality.Repositories
{
    public interface IAirQualityRepository
    {
        public Task<List<AirQualityLocation>> GetLocations(string city);
    }
}
