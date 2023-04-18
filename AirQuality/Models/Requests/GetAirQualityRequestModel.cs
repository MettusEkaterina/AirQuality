using System.ComponentModel.DataAnnotations;

namespace AirQuality.Models.Requests
{
    public class GetAirQualityRequestModel
    {
        public Meta Meta { get; set; }
        [Required]
        public List<AirQualityLocation> Results { get; set; }
    }

    public class Meta
    {
        public string Name { get; set; }
        public string Licence { get; set; }
        public string Website { get; set; }
        public int? Page { get; set; }
        public int? Limit { get; set; }
        public int? Found { get; set; }
    }

    public class AirQualityLocation
    {
        [Required]
        public int Id { get; set; }
        public string City { get; set; }
        public string Name { get; set; }
        public string Entity { get; set; }
        public string Country { get; set; }
        public List<Source> Sources { get; set; }
        [Required]
        public bool IsMobile { get; set; }
        public bool? IsAnalysis { get; set; }
        [Required]
        public List<Parameter> Parameters { get; set; }
        public string SensorType { get; set; }
        public Coordinates Coordinates { get; set; }
        [Required]
        public string LastUpdated { get; set; }
        [Required]
        public string FirstUpdated { get; set; }
        [Required]
        public int Measurements { get; set; }
        public List<double> Bounds { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
    }

    public class Coordinates
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
    }

    public class Parameter
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Unit { get; set; }
        [Required]
        public int Count { get; set; }
        [Required]
        public double Average { get; set; }
        [Required]
        public double LastValue { get; set; }
        [Required]
        public string parameter { get; set; }
        public string DisplayName { get; set; }
        [Required]
        public string LastUpdated { get; set; }
        [Required]
        public int ParameterId { get; set; }
        [Required]
        public string FirstUpdated { get; set; }
        public List<Manufacturer> Manufacturers { get; set; }
    }

    public class Manufacturer
    {
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string ManufacturerName { get; set; }
    }

    public class Source
    {
        public string Url { get; set; }
        [Required]
        public string Name { get; set; }
        public string Id { get; set; }
        public string Readme { get; set; }
        public string Organization { get; set; }
        public string Lifecycle_stage { get; set; }
    }
}
