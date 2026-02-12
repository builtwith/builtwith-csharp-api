using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class TagResult
    {
        [JsonPropertyName("Value")]
        public string? Value { get; set; }

        [JsonPropertyName("Matches")]
        public TagMatch[]? Matches { get; set; }
    }

    public class TagMatch
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("First")]
        public string? First { get; set; }

        [JsonPropertyName("Last")]
        public string? Last { get; set; }
    }
}
