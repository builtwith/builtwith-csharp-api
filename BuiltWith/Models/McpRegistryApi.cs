using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class McpRegistryResponse
    {
        /// <summary>Complete v2 records, including per-endpoint discovery overviews.</summary>
        public McpRegistryV2Result[]? Servers { get; set; }

        [JsonPropertyName("Search")]
        public string? Search { get; set; }

        [JsonPropertyName("Results")]
        public McpRegistryResult[]? Results { get; set; }

        [JsonPropertyName("Errors")]
        public string[]? Errors { get; set; }
    }

    public class McpRegistryResult
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Category")]
        public string? Category { get; set; }

        [JsonPropertyName("Endpoints")]
        public string[]? Endpoints { get; set; }

        [JsonPropertyName("Tools")]
        public McpRegistryTool[]? Tools { get; set; }
    }

    public class McpRegistryTool
    {
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }
    }
}
