# BuiltWith C# Client SDK

C# client SDK for the [BuiltWith API](https://api.builtwith.com). ![.NET](https://github.com/builtwith/BuiltWith-C-Client-API/workflows/.NET/badge.svg?branch=master)

## Getting Started

```csharp
using var client = new BuiltWith.BuiltWithClient("YOUR_API_KEY");

// Domain API - get technologies used on a domain
var domain = await client.GetDomainAsync("example.com");

// Free API - get technology group summary
var free = await client.GetFreeAsync("example.com");
```

Get your API key by creating a free account at [api.builtwith.com](https://api.builtwith.com).

## Installing

```
dotnet add package BuiltWith
```

https://www.nuget.org/packages/BuiltWith/

## Supported Endpoints

- [x] [Domain API](https://api.builtwith.com/domain-api) - Technology detection for domains (v23)
- [x] [Change API](https://api.builtwith.com/change-api) - Technology additions and removals
- [x] [Free API](https://api.builtwith.com/free-api) - Free technology group summary
- [x] [Lists API](https://api.builtwith.com/lists-api) - Find sites using a technology
- [x] [Relationships API](https://api.builtwith.com/relationships-api) - Domain relationship mapping
- [x] [Keywords API](https://api.builtwith.com/keywords-api) - Domain keyword extraction
- [x] [Trends API](https://api.builtwith.com/trends-api) - Technology adoption trends
- [x] [Company to URL API](https://api.builtwith.com/company-to-url) - Map company names to domains
- [x] [Tags API](https://api.builtwith.com/tag-api) - IP and attribute lookups
- [x] [Redirects API](https://api.builtwith.com/redirect-api) - Domain redirect tracking
- [x] [Trust API](https://api.builtwith.com/trust-api) - Trust and fraud signals
- [x] [VAT API](https://api.builtwith.com/vat-api) - VAT, GST, and other company registration numbers
- [x] [MCP API](https://api.builtwith.com/mcp-api) - Search and browse the BuiltWith MCP registry of discovered remote MCP servers (v1 & v2)
- [x] [Recommendations API](https://api.builtwith.com/recommendations-api) - Technology recommendations
- [x] [Product API](https://api.builtwith.com/product-api) - E-commerce product search
- [x] [Vector Search API](https://api.builtwith.com/vector-api) - Semantic technology and category search
- [x] [Ask API](https://api.builtwith.com/ask-api) - Natural language website list lookup
- [x] Agent Device-Code Authorization - Obtain a temporary API token via browser approval (no API key required)

## Usage Examples

### Domain API

```csharp
using var client = new BuiltWith.BuiltWithClient("YOUR_API_KEY");

// Single domain
var result = await client.GetDomainAsync("shopify.com");
foreach (var tech in result.Results[0].Result.Paths[0].Technologies)
{
    Console.WriteLine($"{tech.Name} ({tech.Tag})");
}

// Multiple domains (max 16)
var multi = await client.GetDomainAsync(new[] { "shopify.com", "builtwith.com" });
```

### Change API

```csharp
var changes = await client.GetChangeAsync("builtwith.com", since: "last month");
foreach (var item in changes.Results)
{
    Console.WriteLine(item.Changes?.Summary);
}

var multiChanges = await client.GetChangeAsync(new[] { "shopify.com", "builtwith.com" });
```

### Lists API

```csharp
// Find sites using Shopify
var list = await client.GetListsAsync("Shopify");
var gaAndPixel = await client.GetListsAsync("Google-Analytics", otherTechs: "Meta-Pixel");
var filtered = await client.GetListsAsync("Shopify", filters: new Dictionary<string, string>
{
    ["REVENUE"] = "100000|GT",
    ["SPEND"] = "100|GTE",
    ["EMPLOYEES"] = "50|GTE"
});
foreach (var site in list.Results)
{
    Console.WriteLine(site.Domain);
}

// Paginate with offset
var next = await client.GetListsAsync("Shopify", list.NextOffset);
```

### Relationships API

```csharp
var rel = await client.GetRelationshipsAsync("builtwith.com");
foreach (var r in rel.Relationships)
{
    foreach (var id in r.Identifiers)
    {
        Console.WriteLine($"{id.Type}: {id.Value} ({id.Matches?.Length} matches)");
    }
}
```

### Company to URL API

```csharp
var companies = await client.GetCompanyToUrlAsync("BuiltWith");
foreach (var c in companies)
{
    Console.WriteLine($"{c.Domain} - {c.CompanyName} ({c.Country})");
}
```

### Trends API

```csharp
var trends = await client.GetTrendsAsync("Shopify");
Console.WriteLine($"{trends.Tech.Name}: {trends.Tech.Coverage.Live} live sites");
```

### Trust API

```csharp
var trust = await client.GetTrustAsync("example.com");
Console.WriteLine($"TrustLevel: {trust.Assessment?.TrustLevel}, Spend: {trust.BusinessProfile?.EstimatedMonthlySpendUSD}");
```

### VAT API

```csharp
var vat = await client.GetVatAsync("builtwith.com");
Console.WriteLine($"{vat[0].Type}: {vat[0].Number}");

var vatTypes = await client.GetVatTypesAsync();
Console.WriteLine($"{vatTypes[0].Type}: {vatTypes[0].Description}");
```

### MCP Registry API

```csharp
var mcp = await client.GetMcpRegistryAsync(search: "payments");
Console.WriteLine($"{mcp.Results?[0].Domain}: {mcp.Results?[0].Description}");
```

### MCP Registry API (v2)

Adds per-endpoint `AuthRequired` flags and `FirstDetected`/`LastDetected` dates over v1.

```csharp
var mcpV2 = await client.GetMcpRegistryV2Async(search: "payments");
Console.WriteLine($"{mcpV2[0].Domain}: {mcpV2[0].Endpoints?[0].AuthRequired}");
```

### Redirects API

```csharp
var redirects = await client.GetRedirectsAsync("builtwith.com");
Console.WriteLine($"Inbound: {redirects.Inbound?.Length}, Outbound: {redirects.Outbound?.Length}");
```

### Tags API

```csharp
var tags = await client.GetTagsAsync("IP-104.18.44.82");
foreach (var tag in tags)
{
    Console.WriteLine($"{tag.Value}: {tag.Matches?.Length} domains");
}
```

### Product API

```csharp
var products = await client.GetProductAsync("bluetooth speaker");
foreach (var shop in products.Shops)
{
    foreach (var p in shop.Products)
    {
        Console.WriteLine($"{p.Title} - ${p.Price} at {shop.Domain}");
    }
}
```

### Recommendations API

```csharp
var recs = await client.GetRecommendationsAsync("builtwith.com");
foreach (var r in recs[0].Recommendations)
{
    Console.WriteLine($"{r.Name} ({r.Tag}) - {r.Stars} stars, {r.Match:P0} match");
}
```

### Keywords API

```csharp
var kw = await client.GetKeywordsAsync("builtwith.com");
Console.WriteLine(string.Join(", ", kw.Keywords[0].Keywords));
```

### Vector Search API

```csharp
var results = await client.GetVectorSearchAsync("react framework");
foreach (var r in results.Results)
{
    Console.WriteLine($"{r.Name} ({r.Type}) - score: {r.Score:F2}");
}

// With limit
var limited = await client.GetVectorSearchAsync("ecommerce platform", limit: 5);
```

### Ask API

Natural language website list lookup. Without `commit`, returns a sample (1 API credit). Set `commit: true` for a full report of up to 1,000 results. Paginate using `nextOffset` from the previous response; `"END"` means no more pages.

```csharp
// Quick sample
var result = await client.GetAskAsync("Magento websites in Spain");
Console.WriteLine(result.Explanation);
foreach (var r in result.Results)
{
    Console.WriteLine($"{r.D} ({r.Country})");
}

// Full report
var full = await client.GetAskAsync("Shopify stores in the US", commit: true);

// Paginate
var page2 = await client.GetAskAsync("Shopify stores in the US", commit: true, nextOffset: full.NextOffset);
```

### Agent Device-Code Authorization

Obtain a temporary `bw-` prefixed API token via browser approval. These are **static methods** — no `BuiltWithClient` instance or API key required.

```csharp
// Step 1: start the flow
var start = await BuiltWithClient.AgentAuthStartAsync();
// start.VerificationUri => URL to open in browser
// start.DeviceCode      => code to poll with

Console.WriteLine($"Open in browser: {start.VerificationUri}");

// Step 2: poll every 5 seconds
AgentAuthTokenResponse token;
do {
    await Task.Delay(5000);
    token = await BuiltWithClient.AgentAuthTokenAsync(start.DeviceCode);
} while (token.Status == "pending");

if (token.Status == "approved") {
    using var client = new BuiltWithClient(token.AccessToken);
    // use client normally
}
```

Synchronous equivalents are also available:

```csharp
var start = BuiltWithClient.AgentAuthStart();
var token = BuiltWithClient.AgentAuthToken(start.DeviceCode);
```

### Synchronous Usage

All async methods have synchronous counterparts:

```csharp
var domain = client.GetDomain("example.com");
var free = client.GetFree("example.com");
var trust = client.GetTrust("example.com");
```

### Custom HttpClient

```csharp
var httpClient = new HttpClient();
httpClient.Timeout = TimeSpan.FromSeconds(60);

using var client = new BuiltWith.BuiltWithClient("YOUR_API_KEY", httpClient);
```

## Dependencies

* .NET 8.0 / .NET Standard 2.0
* System.Text.Json

## Migrating from v1

v2 is a complete rewrite. Key changes:

- **Instance-based client** - Use `new BuiltWithClient(key)` instead of `BuiltWithClient.Init(key)` + static methods
- **IDisposable** - Wrap in `using` statement
- **Async-first** - All methods have `Async` variants with `CancellationToken` support
- **System.Text.Json** - Replaced Newtonsoft.Json
- **Domain API v23** - Updated from v14
- **All endpoints** - Full coverage of the BuiltWith API

## Licence

MIT

## Authors

Gary Brewer
