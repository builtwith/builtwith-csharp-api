using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class RecommendationResult
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Compiled")]
        public string? Compiled { get; set; }

        [JsonPropertyName("Recommendations")]
        public Recommendation[]? Recommendations { get; set; }
    }

    public class Recommendation
    {
        [JsonPropertyName("link")]
        public string? Link { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("tag")]
        public string? Tag { get; set; }

        [JsonPropertyName("categories")]
        public string[]? Categories { get; set; }

        [JsonPropertyName("stars")]
        public int Stars { get; set; }

        [JsonPropertyName("match")]
        public double Match { get; set; }
    }
}
