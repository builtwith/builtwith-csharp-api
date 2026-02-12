using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class ListsApiResponse
    {
        [JsonPropertyName("NextOffset")]
        public string? NextOffset { get; set; }

        [JsonPropertyName("Results")]
        public ListResult[]? Results { get; set; }
    }

    public class ListResult
    {
        [JsonPropertyName("D")]
        public string? Domain { get; set; }

        [JsonPropertyName("FI")]
        public long FirstIndexed { get; set; }

        [JsonPropertyName("LI")]
        public long LastIndexed { get; set; }

        [JsonPropertyName("LOS")]
        public string[]? SubDomains { get; set; }

        [JsonPropertyName("Q")]
        public long QRank { get; set; }

        [JsonPropertyName("A")]
        public long ARank { get; set; }

        [JsonPropertyName("U")]
        public long Umbrella { get; set; }

        [JsonPropertyName("M")]
        public long Majestic { get; set; }

        [JsonPropertyName("SKU")]
        public long SKU { get; set; }

        [JsonPropertyName("F")]
        public long F { get; set; }

        [JsonPropertyName("E")]
        public long E { get; set; }

        [JsonPropertyName("FD")]
        public long FirstDetected { get; set; }

        [JsonPropertyName("LD")]
        public long LastDetected { get; set; }

        [JsonPropertyName("S")]
        public long Spend { get; set; }

        [JsonPropertyName("R")]
        public long Rank { get; set; }

        [JsonPropertyName("Country")]
        public string? Country { get; set; }
    }
}
