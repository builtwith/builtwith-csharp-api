using System.Text.Json.Serialization;

namespace BuiltWith.Models
{
    public class ProductApiResponse
    {
        [JsonPropertyName("query")]
        public string? Query { get; set; }

        [JsonPropertyName("is_more")]
        public bool IsMore { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("results")]
        public int Results { get; set; }

        [JsonPropertyName("shop_count")]
        public int ShopCount { get; set; }

        [JsonPropertyName("credits")]
        public int Credits { get; set; }

        [JsonPropertyName("used")]
        public int Used { get; set; }

        [JsonPropertyName("remaining")]
        public int Remaining { get; set; }

        [JsonPropertyName("used_this_query")]
        public int UsedThisQuery { get; set; }

        [JsonPropertyName("next_page")]
        public string? NextPage { get; set; }

        [JsonPropertyName("shops")]
        public ProductShop[]? Shops { get; set; }
    }

    public class ProductShop
    {
        [JsonPropertyName("Domain")]
        public string? Domain { get; set; }

        [JsonPropertyName("Type")]
        public int Type { get; set; }

        [JsonPropertyName("Spend")]
        public double Spend { get; set; }

        [JsonPropertyName("Products")]
        public Product[]? Products { get; set; }
    }

    public class Product
    {
        [JsonPropertyName("Title")]
        public string? Title { get; set; }

        [JsonPropertyName("Url")]
        public string? Url { get; set; }

        [JsonPropertyName("Indexed")]
        public string? Indexed { get; set; }

        [JsonPropertyName("FirstIndexed")]
        public string? FirstIndexed { get; set; }

        [JsonPropertyName("Price")]
        public double Price { get; set; }
    }
}
