using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class AgentAuthStartResponse
    {
        [JsonPropertyName("device_code")]
        public string? DeviceCode { get; set; }

        [JsonPropertyName("verification_uri")]
        public string? VerificationUri { get; set; }

        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }

        [JsonPropertyName("interval")]
        public int? Interval { get; set; }
    }

    public class AgentAuthTokenResponse
    {
        /// <summary>Populated on approval: the bw-... token to use as KEY on any BuiltWith endpoint.</summary>
        [JsonPropertyName("access_token")]
        public string? AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string? TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; }

        /// <summary>Populated when not yet approved: "authorization_pending", "access_denied", "expired_token", "server_error".</summary>
        [JsonPropertyName("error")]
        public string? Error { get; set; }

        [JsonPropertyName("error_description")]
        public string? ErrorDescription { get; set; }
    }
}
