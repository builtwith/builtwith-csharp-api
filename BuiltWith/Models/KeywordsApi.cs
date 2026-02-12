using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class KeywordsApiResponse
    {
        [JsonPropertyName("Keywords")]
        public KeywordResult[]? Keywords { get; set; }
    }

    public class KeywordResult
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Keywords")]
        public string[]? Keywords { get; set; }
    }
}
