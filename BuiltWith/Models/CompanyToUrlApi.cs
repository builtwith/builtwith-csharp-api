using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class CompanyToUrlResult
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("CompanyName")]
        public string? CompanyName { get; set; }

        [JsonPropertyName("Spend")]
        public long Spend { get; set; }

        [JsonPropertyName("PageRank")]
        public long PageRank { get; set; }

        [JsonPropertyName("BuiltWithRank")]
        public long BuiltWithRank { get; set; }

        [JsonPropertyName("Parked")]
        public bool Parked { get; set; }

        [JsonPropertyName("Country")]
        public string? Country { get; set; }

        [JsonPropertyName("State")]
        public string? State { get; set; }

        [JsonPropertyName("Postcode")]
        public string? Postcode { get; set; }

        [JsonPropertyName("City")]
        public string? City { get; set; }

        [JsonPropertyName("Socials")]
        public string[]? Socials { get; set; }
    }
}
