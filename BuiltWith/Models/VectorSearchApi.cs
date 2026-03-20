using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class VectorSearchResponse
    {
        [JsonPropertyName("Query")]
        public string? Query { get; set; }

        [JsonPropertyName("Results")]
        public VectorSearchResult[]? Results { get; set; }

        [JsonPropertyName("Errors")]
        public string[]? Errors { get; set; }
    }

    public class VectorSearchResult
    {
        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Tag")]
        public string? Tag { get; set; }

        [JsonPropertyName("Score")]
        public double Score { get; set; }

        [JsonPropertyName("Icon")]
        public string? Icon { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Categories")]
        public string[]? Categories { get; set; }

        [JsonPropertyName("IsPremium")]
        public bool IsPremium { get; set; }

        [JsonPropertyName("Link")]
        public string? Link { get; set; }

        [JsonPropertyName("TrendsLink")]
        public string? TrendsLink { get; set; }
    }
}
