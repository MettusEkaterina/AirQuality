using AirQuality.Models.Requests;
using Flurl;
using Flurl.Http;
using ConfigurationManager = System.Configuration.ConfigurationManager;

namespace AirQuality.Repositories
{
    public class AirQualityRepository : IAirQualityRepository
    {
        private readonly string _getLocationsUrl;
        private readonly ILogger<AirQualityRepository> _logger;

        public AirQualityRepository(ILogger<AirQualityRepository> logger)
        {
            var getLocationsUrl = ConfigurationManager.AppSettings["getLocationsUrl"];
            _getLocationsUrl = getLocationsUrl != null ? getLocationsUrl : string.Empty;
            _logger = logger;
        }

        public async Task<List<AirQualityLocation>> GetLocations(string givenCity)
        {
            try
            {
                var airQualityData = await _getLocationsUrl
                 .SetQueryParams( new
                 {
                     limit = 100,
                     city = givenCity,
                     page = 1,
                     offset = 0,
                     sort = "desc",
                     radius = 1000,
                     order_by = "lastUpdated",
                     dumpRaw = false
                 })
                 .GetJsonAsync<GetAirQualityRequestModel>();

                return airQualityData.Results;
            }
            catch (FlurlHttpException ex)
            {
                var error = await ex.GetResponseJsonAsync<FlurlHttpException>();
                _logger.LogError($"Error returned from {ex.Call.Request.Url}: {error.Message}");

                return new List<AirQualityLocation>();
            }
        }
    }
}
