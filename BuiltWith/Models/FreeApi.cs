using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class FreeApiResponse
    {
        [JsonPropertyName("domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("first")]
        public long First { get; set; }

        [JsonPropertyName("last")]
        public long Last { get; set; }

        [JsonPropertyName("groups")]
        public FreeGroup[]? Groups { get; set; }
    }

    public class FreeGroup
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("live")]
        public int Live { get; set; }

        [JsonPropertyName("dead")]
        public int Dead { get; set; }

        [JsonPropertyName("latest")]
        public long Latest { get; set; }

        [JsonPropertyName("oldest")]
        public long Oldest { get; set; }

        [JsonPropertyName("categories")]
        public FreeCategory[]? Categories { get; set; }
    }

    public class FreeCategory
    {
        [JsonPropertyName("live")]
        public int Live { get; set; }

        [JsonPropertyName("dead")]
        public int Dead { get; set; }

        [JsonPropertyName("latest")]
        public long Latest { get; set; }

        [JsonPropertyName("oldest")]
        public long Oldest { get; set; }

        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}
