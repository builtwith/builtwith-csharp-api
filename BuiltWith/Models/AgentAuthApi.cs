using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class AgentAuthStartResponse
    {
        [JsonPropertyName("device_code")]
        public string? DeviceCode { get; set; }

        [JsonPropertyName("verification_uri")]
        public string? VerificationUri { get; set; }
    }

    public class AgentAuthTokenResponse
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; }

        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }
    }
}
