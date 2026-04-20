using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using BuiltWith.Exceptions;
using BuiltWith.Models;

namespace BuiltWith
{
    /// <summary>
    /// Client for the BuiltWith API.
    /// </summary>
    public sealed class BuiltWithClient : IDisposable
    {
        private const string BaseUrl = "https://api.builtwith.com";

        private static readonly JsonSerializerOptions JsonOptions = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly bool _ownsHttpClient;

        /// <summary>
        /// Creates a new BuiltWithClient with the specified API key.
        /// Get your key at https://api.builtwith.com
        /// </summary>
        public BuiltWithClient(string apiKey)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new BuiltWithException("API key cannot be null or empty.");

            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("builtwith-csharp/2.0");
            _ownsHttpClient = true;
        }

        /// <summary>
        /// Creates a new BuiltWithClient with the specified API key and a custom HttpClient.
        /// </summary>
        public BuiltWithClient(string apiKey, HttpClient httpClient)
        {
            if (string.IsNullOrEmpty(apiKey))
                throw new BuiltWithException("API key cannot be null or empty.");

            _apiKey = apiKey;
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _ownsHttpClient = false;
        }

        #region Domain API (v22)

        /// <summary>
        /// Look up technology information for a single domain.
        /// https://api.builtwith.com/domain-api
        /// </summary>
        public async Task<DomainApiResponse> GetDomainAsync(string domain, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/v22/api.json", ("LOOKUP", domain));
            return await GetAsync<DomainApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Look up technology information for multiple domains (max 16).
        /// </summary>
        public async Task<DomainApiResponse> GetDomainAsync(string[] domains, CancellationToken cancellationToken = default)
        {
            if (domains == null || domains.Length == 0)
                throw new BuiltWithException("At least one domain is required.");
            if (domains.Length > 16)
                throw new BuiltWithException("Maximum 16 domains at a time.");

            var url = BuildUrl("/v22/api.json", ("LOOKUP", string.Join(",", domains)));
            return await GetAsync<DomainApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Synchronous wrapper for GetDomainAsync.
        /// </summary>
        public DomainApiResponse GetDomain(string domain) =>
            GetDomainAsync(domain).GetAwaiter().GetResult();

        /// <summary>
        /// Synchronous wrapper for GetDomainAsync (multi-domain).
        /// </summary>
        public DomainApiResponse GetDomain(params string[] domains) =>
            GetDomainAsync(domains).GetAwaiter().GetResult();

        #endregion

        #region Free API

        /// <summary>
        /// Get a free summary of technology groups for a domain.
        /// https://api.builtwith.com/free-api
        /// </summary>
        public async Task<FreeApiResponse> GetFreeAsync(string domain, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/free1/api.json", ("LOOKUP", domain));
            return await GetAsync<FreeApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public FreeApiResponse GetFree(string domain) =>
            GetFreeAsync(domain).GetAwaiter().GetResult();

        #endregion

        #region Lists API

        /// <summary>
        /// Get a list of domains using a specific technology.
        /// https://api.builtwith.com/lists-api
        /// </summary>
        public async Task<ListsApiResponse> GetListsAsync(string tech, string? offset = null, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/lists12/api.json", ("TECH", tech));
            if (!string.IsNullOrEmpty(offset))
                url += "&OFFSET=" + WebUtility.UrlEncode(offset);
            return await GetAsync<ListsApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public ListsApiResponse GetLists(string tech, string? offset = null) =>
            GetListsAsync(tech, offset).GetAwaiter().GetResult();

        #endregion

        #region Relationships API

        /// <summary>
        /// Discover relationships between domains via shared identifiers.
        /// https://api.builtwith.com/relationships-api
        /// </summary>
        public async Task<RelationshipsApiResponse> GetRelationshipsAsync(string domain, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/rv4/api.json", ("LOOKUP", domain));
            return await GetAsync<RelationshipsApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public RelationshipsApiResponse GetRelationships(string domain) =>
            GetRelationshipsAsync(domain).GetAwaiter().GetResult();

        #endregion

        #region Keywords API

        /// <summary>
        /// Get keywords associated with a domain.
        /// https://api.builtwith.com/keywords-api
        /// </summary>
        public async Task<KeywordsApiResponse> GetKeywordsAsync(string domain, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/kw2/api.json", ("LOOKUP", domain));
            return await GetAsync<KeywordsApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public KeywordsApiResponse GetKeywords(string domain) =>
            GetKeywordsAsync(domain).GetAwaiter().GetResult();

        #endregion

        #region Trends API

        /// <summary>
        /// Get technology adoption trend data.
        /// https://api.builtwith.com/trends-api
        /// </summary>
        public async Task<TrendsApiResponse> GetTrendsAsync(string tech, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/trends/v6/api.json", ("TECH", tech));
            return await GetAsync<TrendsApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public TrendsApiResponse GetTrends(string tech) =>
            GetTrendsAsync(tech).GetAwaiter().GetResult();

        #endregion

        #region Company to URL API

        /// <summary>
        /// Find domains associated with a company name.
        /// https://api.builtwith.com/company-to-url
        /// </summary>
        public async Task<CompanyToUrlResult[]> GetCompanyToUrlAsync(string company, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/ctu3/api.json", ("COMPANY", company));
            return await GetAsync<CompanyToUrlResult[]>(url, cancellationToken).ConfigureAwait(false);
        }

        public CompanyToUrlResult[] GetCompanyToUrl(string company) =>
            GetCompanyToUrlAsync(company).GetAwaiter().GetResult();

        #endregion

        #region Tags API

        /// <summary>
        /// Find domains associated with an IP address or attribute.
        /// Use format "IP-1.2.3.4" for IP lookups.
        /// https://api.builtwith.com/tag-api
        /// </summary>
        public async Task<TagResult[]> GetTagsAsync(string lookup, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/tag1/api.json", ("LOOKUP", lookup));
            return await GetAsync<TagResult[]>(url, cancellationToken).ConfigureAwait(false);
        }

        public TagResult[] GetTags(string lookup) =>
            GetTagsAsync(lookup).GetAwaiter().GetResult();

        #endregion

        #region Redirects API

        /// <summary>
        /// Get inbound and outbound redirect information for a domain.
        /// https://api.builtwith.com/redirect-api
        /// </summary>
        public async Task<RedirectsApiResponse> GetRedirectsAsync(string domain, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/redirect1/api.json", ("LOOKUP", domain));
            return await GetAsync<RedirectsApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public RedirectsApiResponse GetRedirects(string domain) =>
            GetRedirectsAsync(domain).GetAwaiter().GetResult();

        #endregion

        #region Trust API

        /// <summary>
        /// Get trust and fraud signals for a domain.
        /// https://api.builtwith.com/trust-api
        /// </summary>
        public async Task<TrustApiResponse> GetTrustAsync(string domain, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/trustv1/api.json", ("LOOKUP", domain));
            return await GetAsync<TrustApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public TrustApiResponse GetTrust(string domain) =>
            GetTrustAsync(domain).GetAwaiter().GetResult();

        #endregion

        #region Recommendations API

        /// <summary>
        /// Get technology recommendations for a domain.
        /// https://api.builtwith.com/recommendations-api
        /// </summary>
        public async Task<RecommendationResult[]> GetRecommendationsAsync(string domain, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/rec1/api.json", ("LOOKUP", domain));
            return await GetAsync<RecommendationResult[]>(url, cancellationToken).ConfigureAwait(false);
        }

        public RecommendationResult[] GetRecommendations(string domain) =>
            GetRecommendationsAsync(domain).GetAwaiter().GetResult();

        #endregion

        #region Product API

        /// <summary>
        /// Search for e-commerce sites selling specific products.
        /// https://api.builtwith.com/product-api
        /// </summary>
        public async Task<ProductApiResponse> GetProductAsync(string query, int page = 0, int? limit = null, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/productv1/api.json", ("QUERY", query));
            if (page > 0)
                url += "&PAGE=" + page;
            if (limit.HasValue)
                url += "&LIMIT=" + limit.Value;
            return await GetAsync<ProductApiResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public ProductApiResponse GetProduct(string query, int page = 0, int? limit = null) =>
            GetProductAsync(query, page, limit).GetAwaiter().GetResult();

        #endregion

        #region Vector Search API

        /// <summary>
        /// Search for technologies and categories using semantic similarity.
        /// https://api.builtwith.com/vector-api
        /// </summary>
        public async Task<VectorSearchResponse> GetVectorSearchAsync(string query, int? limit = null, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/vector/v1/api.json", ("QUERY", query));
            if (limit.HasValue)
                url += "&LIMIT=" + limit.Value;
            return await GetAsync<VectorSearchResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public VectorSearchResponse GetVectorSearch(string query, int? limit = null) =>
            GetVectorSearchAsync(query, limit).GetAwaiter().GetResult();

        #endregion

        #region Keyword Search API

        /// <summary>
        /// Find websites containing a specific keyword.
        /// https://api.builtwith.com/keyword-search-api
        /// </summary>
        public async Task<KeywordSearchResponse> GetKeywordSearchAsync(string keyword, int? limit = null, string? offset = null, CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/kws1/api.json", ("KEYWORD", keyword));
            if (limit.HasValue)
                url += "&LIMIT=" + limit.Value;
            if (!string.IsNullOrEmpty(offset))
                url += "&OFFSET=" + WebUtility.UrlEncode(offset);
            return await GetAsync<KeywordSearchResponse>(url, cancellationToken).ConfigureAwait(false);
        }

        public KeywordSearchResponse GetKeywordSearch(string keyword, int? limit = null, string? offset = null) =>
            GetKeywordSearchAsync(keyword, limit, offset).GetAwaiter().GetResult();

        #endregion

        #region Utility Endpoints

        /// <summary>
        /// Verify your API key and get account information.
        /// </summary>
        public async Task<JsonElement> GetWhoAmIAsync(CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/whoamiv1/api.json");
            return await GetAsync<JsonElement>(url, cancellationToken).ConfigureAwait(false);
        }

        /// <summary>
        /// Get API usage and credit information.
        /// </summary>
        public async Task<JsonElement> GetUsageAsync(CancellationToken cancellationToken = default)
        {
            var url = BuildUrl("/usagev2/api.json");
            return await GetAsync<JsonElement>(url, cancellationToken).ConfigureAwait(false);
        }

        #endregion

        #region Agent Device-Code Authorization

        /// <summary>
        /// Start the Agent Device-Code Authorization flow. No API key required.
        /// Returns a device_code and verification_uri. Direct the user to open the URI in their browser.
        /// </summary>
        public static async Task<AgentAuthStartResponse> AgentAuthStartAsync(HttpClient httpClient = null, CancellationToken cancellationToken = default)
        {
            bool ownsClient = httpClient == null;
            httpClient ??= new HttpClient();
            try
            {
                using var content = new System.Net.Http.StringContent("{}", System.Text.Encoding.UTF8, "application/json");
                using var response = await httpClient.PostAsync(BaseUrl + "/agent-auth/start", content, cancellationToken).ConfigureAwait(false);
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonSerializer.Deserialize<AgentAuthStartResponse>(json, JsonOptions)!;
            }
            finally
            {
                if (ownsClient) httpClient.Dispose();
            }
        }

        /// <summary>Synchronous wrapper for <see cref="AgentAuthStartAsync"/>.</summary>
        public static AgentAuthStartResponse AgentAuthStart(HttpClient httpClient = null) =>
            AgentAuthStartAsync(httpClient).GetAwaiter().GetResult();

        /// <summary>
        /// Poll for the result of an Agent Device-Code Authorization flow. No API key required.
        /// Call every 5 seconds after AgentAuthStart. Returns status and, on approval, an access_token.
        /// </summary>
        public static async Task<AgentAuthTokenResponse> AgentAuthTokenAsync(string deviceCode, HttpClient httpClient = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(deviceCode))
                throw new ArgumentException("deviceCode is required", nameof(deviceCode));

            bool ownsClient = httpClient == null;
            httpClient ??= new HttpClient();
            try
            {
                var body = System.Text.Json.JsonSerializer.Serialize(new { device_code = deviceCode });
                using var content = new System.Net.Http.StringContent(body, System.Text.Encoding.UTF8, "application/json");
                using var response = await httpClient.PostAsync(BaseUrl + "/agent-auth/token", content, cancellationToken).ConfigureAwait(false);
                var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return JsonSerializer.Deserialize<AgentAuthTokenResponse>(json, JsonOptions)!;
            }
            finally
            {
                if (ownsClient) httpClient.Dispose();
            }
        }

        /// <summary>Synchronous wrapper for <see cref="AgentAuthTokenAsync"/>.</summary>
        public static AgentAuthTokenResponse AgentAuthToken(string deviceCode, HttpClient httpClient = null) =>
            AgentAuthTokenAsync(deviceCode, httpClient).GetAwaiter().GetResult();

        #endregion

        #region Internals

        private string BuildUrl(string path, params (string key, string value)[] queryParams)
        {
            var url = BaseUrl + path + "?KEY=" + WebUtility.UrlEncode(_apiKey);
            foreach (var (key, value) in queryParams)
            {
                if (!string.IsNullOrEmpty(value))
                    url += "&" + WebUtility.UrlEncode(key) + "=" + WebUtility.UrlEncode(value);
            }
            return url;
        }

        private async Task<T> GetAsync<T>(string url, CancellationToken cancellationToken)
        {
            HttpResponseMessage response;
            try
            {
                response = await _httpClient.GetAsync(url, cancellationToken).ConfigureAwait(false);
            }
            catch (OperationCanceledException)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new ApiException("Connection error: " + ex.Message, ex);
            }

#if NET8_0_OR_GREATER
            var json = await response.Content.ReadAsStringAsync(cancellationToken).ConfigureAwait(false);
#else
            var json = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
#endif

            if (!response.IsSuccessStatusCode)
                throw new ApiException("API returned HTTP " + (int)response.StatusCode + ": " + json, (int)response.StatusCode);

            try
            {
                var result = JsonSerializer.Deserialize<T>(json, JsonOptions);
                if (result == null)
                    throw new ApiException("API returned null response.");
                return result;
            }
            catch (JsonException ex)
            {
                throw new ApiException("Failed to deserialize API response: " + ex.Message, ex);
            }
        }

        public void Dispose()
        {
            if (_ownsHttpClient)
                _httpClient.Dispose();
        }

        #endregion
    }
}
