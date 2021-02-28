using System.Text.Json.Serialization;

namespace SampleGallery.Web.Models
{
    public class Geo
    {
        [JsonPropertyName("lat")]
        public string Latitude { get; set; }
        [JsonPropertyName("lng")]
        public string Longitude { get; set; }
    }
}
