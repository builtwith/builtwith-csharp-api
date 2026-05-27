using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class AskApiResponse
    {
        [JsonPropertyName("Explanation")]
        public string? Explanation { get; set; }

        [JsonPropertyName("NextOffset")]
        public string? NextOffset { get; set; }

        [JsonPropertyName("Results")]
        public AskResult[]? Results { get; set; }

        [JsonPropertyName("Errors")]
        public object[]? Errors { get; set; }
    }

    public class AskResult
    {
        /// <summary>Domain name</summary>
        [JsonPropertyName("D")]
        public string? D { get; set; }

        /// <summary>First indexed (Unix timestamp)</summary>
        [JsonPropertyName("FI")]
        public long FI { get; set; }

        /// <summary>Last indexed (Unix timestamp)</summary>
        [JsonPropertyName("LI")]
        public long LI { get; set; }

        /// <summary>Country code (ISO 3166-1 alpha-2)</summary>
        [JsonPropertyName("Country")]
        public string? Country { get; set; }

        /// <summary>Quantified score</summary>
        [JsonPropertyName("Q")]
        public int Q { get; set; }

        /// <summary>Sequence / rank</summary>
        [JsonPropertyName("S")]
        public int S { get; set; }
    }
}
