using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class TrustApiResponse
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("DBRecord")]
        public TrustRecord? DBRecord { get; set; }

        [JsonPropertyName("LiveRecord")]
        public TrustRecord? LiveRecord { get; set; }

        [JsonPropertyName("Status")]
        public int Status { get; set; }
    }

    public class TrustRecord
    {
        [JsonPropertyName("EarliestRecord")]
        public long EarliestRecord { get; set; }

        [JsonPropertyName("LatestUpdate")]
        public long LatestUpdate { get; set; }

        [JsonPropertyName("PremiumTechs")]
        public int PremiumTechs { get; set; }

        [JsonPropertyName("LiveTechs")]
        public bool LiveTechs { get; set; }

        [JsonPropertyName("AffiliateLinks")]
        public bool AffiliateLinks { get; set; }

        [JsonPropertyName("PaymentOptions")]
        public bool PaymentOptions { get; set; }

        [JsonPropertyName("Ecommerce")]
        public bool Ecommerce { get; set; }

        [JsonPropertyName("Parked")]
        public bool Parked { get; set; }

        [JsonPropertyName("Spend")]
        public long Spend { get; set; }

        [JsonPropertyName("Established")]
        public bool Established { get; set; }

        [JsonPropertyName("DBIndexed")]
        public bool DBIndexed { get; set; }
    }
}
