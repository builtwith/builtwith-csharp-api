using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuiltWithTest
{
    [TestClass]
    public class CurrentEndpointsTest
    {
        private sealed class Handler : HttpMessageHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
            {
                var uri = request.RequestUri!;
                string json;
                if (uri.AbsolutePath == "/rv5/api.json")
                {
                    StringAssert.Contains(uri.Query, "PAGE=2");
                    StringAssert.Contains(uri.Query, "IP=yes");
                    json = "{\"Relationships\":[],\"page\":2,\"next_page\":3,\"more_results\":true}";
                }
                else
                {
                    Assert.AreEqual("/mcp2/api.json", uri.AbsolutePath);
                    json = "[{\"Domain\":\"example.com\",\"Endpoints\":[{\"Endpoint\":\"https://example.com/mcp\",\"Tools\":[{\"Name\":\"search\"}],\"Overview\":{\"instructions\":\"Search here\"}}]}]";
                }
                return Task.FromResult(new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json) });
            }
        }

        [TestMethod]
        public async Task ReadsPagingAndAdaptsRegistryV2()
        {
            using var http = new HttpClient(new Handler());
            using var client = new BuiltWith.BuiltWithClient("test-key", http);
            var page = await client.GetRelationshipsAsync("example.com", 2, true);
            Assert.AreEqual(2, page.Page);
            Assert.AreEqual(3, page.NextPage);
            Assert.IsTrue(page.MoreResults);
            var registry = await client.GetMcpRegistryAsync("search");
            Assert.AreEqual("https://example.com/mcp", registry.Results![0].Endpoints![0]);
            Assert.AreEqual("search", registry.Results[0].Tools![0].Name);
            Assert.AreEqual("Search here", registry.Servers![0].Endpoints![0].Overview!.Value.GetProperty("instructions").GetString());
            var v2 = await client.GetMcpRegistryV2Async("search");
            Assert.AreEqual("Search here", v2[0].Endpoints![0].Overview!.Value.GetProperty("instructions").GetString());
        }
    }
}
