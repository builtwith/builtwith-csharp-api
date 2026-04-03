using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class KeywordSearchResponse
    {
        [JsonPropertyName("Keyword")]
        public string? Keyword { get; set; }

        [JsonPropertyName("Domains")]
        public string[]? Domains { get; set; }

        [JsonPropertyName("NextOffset")]
        public string? NextOffset { get; set; }
    }
}
