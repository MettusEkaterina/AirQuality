namespace AirQuality.Models
{
    public class PollutantModel
    {
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Unit { get; set; }
        public double Average { get; set; }
        public AirQualityLevel AirQualityLevel { get; set; }
    }
}
