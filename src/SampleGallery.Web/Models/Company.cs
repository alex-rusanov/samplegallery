using System.Text.Json.Serialization;

namespace SampleGallery.Web.Models
{
    public class Company
    {
        public string Name { get; set; }
        public string CatchPhrase { get; set; }
        [JsonPropertyName("bs")]
        public string BusinessStrategy { get; set; }
    }
}
