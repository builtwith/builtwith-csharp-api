using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class VatApiResult
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("Number")]
        public string? Number { get; set; }
    }

    public class VatTypeResult
    {
        [JsonPropertyName("Type")]
        public string? Type { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }
    }
}
