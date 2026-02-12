using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class RelationshipsApiResponse
    {
        [JsonPropertyName("Relationships")]
        public Relationship[]? Relationships { get; set; }

        [JsonPropertyName("Errors")]
        public object[]? Errors { get; set; }

        [JsonPropertyName("results")]
        public int Results { get; set; }

        [JsonPropertyName("max_per_page")]
        public int MaxPerPage { get; set; }

        [JsonPropertyName("next_skip")]
        public int NextSkip { get; set; }

        [JsonPropertyName("more_results")]
        public bool MoreResults { get; set; }
    }

    public class Relationship
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Identifiers")]
        public RelationshipIdentifier[]? Identifiers { get; set; }
    }

    public class RelationshipIdentifier
    {
        [JsonPropertyName("Value")]
        public string? Value { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("First")]
        public long First { get; set; }

        [JsonPropertyName("Last")]
        public long Last { get; set; }

        [JsonPropertyName("Matches")]
        public RelationshipMatch[]? Matches { get; set; }
    }

    public class RelationshipMatch
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("First")]
        public long First { get; set; }

        [JsonPropertyName("Last")]
        public long Last { get; set; }

        [JsonPropertyName("Overlap")]
        public bool Overlap { get; set; }
    }
}
