namespace AirQuality.Models
{
    public class AirQualityModel
    {
        public string City { get; set; }
        public List<AirQualityLocationModel> Locations { get; set; }
    }
}
