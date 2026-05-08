using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class ChangeApiResponse
    {
        [JsonPropertyName("Results")]
        public ChangeResult[]? Results { get; set; }

        [JsonPropertyName("Errors")]
        public string[]? Errors { get; set; }
    }

    public class ChangeResult
    {
        [JsonPropertyName("Lookup")]
        public string? Lookup { get; set; }

        [JsonPropertyName("Changes")]
        public ChangeSet? Changes { get; set; }
    }

    public class ChangeSet
    {
        [JsonPropertyName("since_utc")]
        public string? SinceUtc { get; set; }

        [JsonPropertyName("last_checked_utc")]
        public string? LastCheckedUtc { get; set; }

        [JsonPropertyName("summary")]
        public string? Summary { get; set; }

        [JsonPropertyName("events")]
        public ChangeEvent[]? Events { get; set; }
    }

    public class ChangeEvent
    {
        [JsonPropertyName("type")]
        public string? Type { get; set; }

        [JsonPropertyName("technology")]
        public string? Technology { get; set; }

        [JsonPropertyName("category")]
        public string[]? Category { get; set; }

        [JsonPropertyName("tag")]
        public string? Tag { get; set; }

        [JsonPropertyName("first_seen_utc")]
        public string? FirstSeenUtc { get; set; }

        [JsonPropertyName("last_seen_utc")]
        public string? LastSeenUtc { get; set; }

        [JsonPropertyName("importance")]
        public string? Importance { get; set; }

        [JsonPropertyName("why_this_matters")]
        public string? WhyThisMatters { get; set; }
    }
}
