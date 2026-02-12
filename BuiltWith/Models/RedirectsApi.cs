using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class RedirectsApiResponse
    {
        [JsonPropertyName("Lookup")]
        public string? Lookup { get; set; }

        [JsonPropertyName("Inbound")]
        public RedirectEntry[]? Inbound { get; set; }

        [JsonPropertyName("Outbound")]
        public RedirectEntry[]? Outbound { get; set; }
    }

    public class RedirectEntry
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("FirstDetected")]
        public string? FirstDetected { get; set; }

        [JsonPropertyName("LastDetected")]
        public string? LastDetected { get; set; }
    }
}
