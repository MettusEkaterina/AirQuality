namespace AirQuality.Models
{
    public class AirQualityLocationModel
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }
        public AirQualityLevel AirQualityLevel { get; set; }
        public string LastUpdated { get; set; }
        public List<PollutantModel> Pollutants { get; set; }
    }
}
