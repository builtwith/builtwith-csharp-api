using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class DomainApiResponse
    {
        [JsonPropertyName("Results")]
        public DomainResult[]? Results { get; set; }

        [JsonPropertyName("Errors")]
        public object[]? Errors { get; set; }
    }

    public class DomainResult
    {
        [JsonPropertyName("Result")]
        public DomainResultDetail? Result { get; set; }

        [JsonPropertyName("Meta")]
        public DomainMeta? Meta { get; set; }

        [JsonPropertyName("Attributes")]
        public Dictionary<string, long>? Attributes { get; set; }

        [JsonPropertyName("FirstIndexed")]
        public long FirstIndexed { get; set; }

        [JsonPropertyName("LastIndexed")]
        public long LastIndexed { get; set; }

        [JsonPropertyName("Lookup")]
        public string? Lookup { get; set; }

        [JsonPropertyName("SalesRevenue")]
        public string? SalesRevenue { get; set; }
    }

    public class DomainResultDetail
    {
        [JsonPropertyName("IsDB")]
        public string? IsDb { get; set; }

        [JsonPropertyName("Spend")]
        public long Spend { get; set; }

        [JsonPropertyName("Paths")]
        public DomainPath[]? Paths { get; set; }
    }

    public class DomainMeta
    {
        [JsonPropertyName("Majestic")]
        public long Majestic { get; set; }

        [JsonPropertyName("Umbrella")]
        public long Umbrella { get; set; }

        [JsonPropertyName("Vertical")]
        public string? Vertical { get; set; }

        [JsonPropertyName("Social")]
        public string[]? Social { get; set; }

        [JsonPropertyName("CompanyName")]
        public string? CompanyName { get; set; }

        [JsonPropertyName("Telephones")]
        public string[]? Telephones { get; set; }

        [JsonPropertyName("Emails")]
        public string[]? Emails { get; set; }

        [JsonPropertyName("City")]
        public string? City { get; set; }

        [JsonPropertyName("State")]
        public string? State { get; set; }

        [JsonPropertyName("Postcode")]
        public string? Postcode { get; set; }

        [JsonPropertyName("Country")]
        public string? Country { get; set; }

        [JsonPropertyName("Names")]
        public DomainContact[]? Names { get; set; }

        [JsonPropertyName("ARank")]
        public long ARank { get; set; }

        [JsonPropertyName("QRank")]
        public long QRank { get; set; }
    }

    public class DomainContact
    {
        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Type")]
        public long Type { get; set; }

        [JsonPropertyName("Email")]
        public string? Email { get; set; }
    }

    public class DomainPath
    {
        [JsonPropertyName("FirstIndexed")]
        public long FirstIndexed { get; set; }

        [JsonPropertyName("LastIndexed")]
        public long LastIndexed { get; set; }

        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Url")]
        public string? Url { get; set; }

        [JsonPropertyName("SubDomain")]
        public string? SubDomain { get; set; }

        [JsonPropertyName("Technologies")]
        public DomainTechnology[]? Technologies { get; set; }
    }

    public class DomainTechnology
    {
        [JsonPropertyName("Categories")]
        public string[]? Categories { get; set; }

        [JsonPropertyName("IsPremium")]
        public string? IsPremium { get; set; }

        [JsonPropertyName("Name")]
        public string? Name { get; set; }

        [JsonPropertyName("Description")]
        public string? Description { get; set; }

        [JsonPropertyName("Link")]
        public string? Link { get; set; }

        [JsonPropertyName("Parent")]
        public string? Parent { get; set; }

        [JsonPropertyName("Tag")]
        public string? Tag { get; set; }

        [JsonPropertyName("FirstDetected")]
        public long FirstDetected { get; set; }

        [JsonPropertyName("LastDetected")]
        public long LastDetected { get; set; }
    }
}
