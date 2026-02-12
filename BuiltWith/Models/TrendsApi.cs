using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class TrendsApiResponse
    {
        [JsonPropertyName("Tech")]
        public TechTrend? Tech { get; set; }
    }

    public class TechTrend
    {
        [JsonPropertyName("icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("categories")]
        public string[]? Categories { get; set; }

        [JsonPropertyName("tag")]
        public string? Tag { get; set; }

        [JsonPropertyName("is_premium")]
        public string? IsPremium { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("description")]
        public string? Description { get; set; }

        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("trends_link")]
        public string? TrendsLink { get; set; }

        [JsonPropertyName("coverage")]
        public TechCoverage? Coverage { get; set; }
    }

    public class TechCoverage
    {
        [JsonPropertyName("ten_k")]
        public long TopTenK { get; set; }

        [JsonPropertyName("hundred_k")]
        public long TopHundredK { get; set; }

        [JsonPropertyName("milly")]
        public long TopMillion { get; set; }

        [JsonPropertyName("live")]
        public long Live { get; set; }

        [JsonPropertyName("expired")]
        public long Expired { get; set; }
    }
}
