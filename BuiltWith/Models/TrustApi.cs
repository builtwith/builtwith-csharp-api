using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class TrustApiResponse
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Assessment")]
        public TrustAssessment? Assessment { get; set; }

        [JsonPropertyName("ContentSafety")]
        public TrustContentSafety? ContentSafety { get; set; }

        [JsonPropertyName("BusinessProfile")]
        public TrustBusinessProfile? BusinessProfile { get; set; }

        [JsonPropertyName("LiveVerification")]
        public TrustLiveVerification? LiveVerification { get; set; }
    }

    /// <summary>
    /// One of: Unverified, RestrictedContent, HighRisk, Caution, VerificationRecommended, Neutral, Trusted.
    /// </summary>
    public class TrustAssessment
    {
        [JsonPropertyName("TrustLevel")]
        public string? TrustLevel { get; set; }

        [JsonPropertyName("Summary")]
        public string? Summary { get; set; }

        [JsonPropertyName("Reasons")]
        public List<string>? Reasons { get; set; }
    }

    public class TrustContentSafety
    {
        [JsonPropertyName("Gambling")]
        public bool Gambling { get; set; }

        [JsonPropertyName("AdultContent")]
        public bool AdultContent { get; set; }

        [JsonPropertyName("SuspectedScam")]
        public bool SuspectedScam { get; set; }

        [JsonPropertyName("PlaceholderContent")]
        public bool PlaceholderContent { get; set; }
    }

    public class TrustBusinessProfile
    {
        [JsonPropertyName("IsIndexed")]
        public bool IsIndexed { get; set; }

        [JsonPropertyName("DomainAgeDays")]
        public long DomainAgeDays { get; set; }

        [JsonPropertyName("LastCrawledDaysAgo")]
        public long LastCrawledDaysAgo { get; set; }

        [JsonPropertyName("PremiumTechnologyCount")]
        public int PremiumTechnologyCount { get; set; }

        [JsonPropertyName("HasActiveTechnologyStack")]
        public bool HasActiveTechnologyStack { get; set; }

        [JsonPropertyName("IsParkedDomain")]
        public bool IsParkedDomain { get; set; }

        [JsonPropertyName("IsEcommerceSite")]
        public bool IsEcommerceSite { get; set; }

        [JsonPropertyName("HasPaymentProcessing")]
        public bool HasPaymentProcessing { get; set; }

        [JsonPropertyName("HasAffiliateLinks")]
        public bool HasAffiliateLinks { get; set; }

        [JsonPropertyName("IsEstablishedBusiness")]
        public bool IsEstablishedBusiness { get; set; }

        [JsonPropertyName("EstimatedMonthlySpendUSD")]
        public int EstimatedMonthlySpendUSD { get; set; }
    }

    /// <summary>Only populated when the request included &amp;LIVE=yes.</summary>
    public class TrustLiveVerification
    {
        [JsonPropertyName("LookupSucceeded")]
        public bool LookupSucceeded { get; set; }

        [JsonPropertyName("LookupError")]
        public string? LookupError { get; set; }

        [JsonPropertyName("IsParkedDomain")]
        public bool IsParkedDomain { get; set; }

        [JsonPropertyName("IsEcommerceSite")]
        public bool IsEcommerceSite { get; set; }

        [JsonPropertyName("HasPaymentProcessing")]
        public bool HasPaymentProcessing { get; set; }

        [JsonPropertyName("HasAffiliateLinks")]
        public bool HasAffiliateLinks { get; set; }

        [JsonPropertyName("EstimatedMonthlySpendUSD")]
        public int EstimatedMonthlySpendUSD { get; set; }
    }
}
