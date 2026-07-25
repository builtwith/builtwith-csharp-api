using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class McpRegistryV2Result
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Category")]
        public string? Category { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Endpoints")]
        public McpRegistryV2Endpoint[]? Endpoints { get; set; }

        [JsonPropertyName("first_detected")]
        public string? FirstDetected { get; set; }

        [JsonPropertyName("last_detected")]
        public string? LastDetected { get; set; }
    }

    public class McpRegistryV2Endpoint
    {
        [JsonPropertyName("Endpoint")]
        public string? Endpoint { get; set; }

        [JsonPropertyName("AuthRequired")]
        public bool AuthRequired { get; set; }

        [JsonPropertyName("Tools")]
        public McpRegistryV2Tool[]? Tools { get; set; }
    }

    public class McpRegistryV2Tool
    {
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }
    }
}
