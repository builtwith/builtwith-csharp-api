using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuiltWithTest
{
    [TestClass]
    public class BuiltWithClientTests
    {
        public const string APIKEY = "ENTER YOUR API KEY HERE FOUND AT https://api.builtwith.com";

        [TestMethod]
        [ExpectedException(typeof(BuiltWith.Exceptions.BuiltWithException))]
        public void NoAPIKey()
        {
            var client = new BuiltWith.BuiltWithClient("");
        }

        [TestMethod]
        public void DomainAPISingle()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var domain = client.GetDomain("builtwith.com");
            Assert.IsNotNull(domain);
            Assert.IsNotNull(domain.Results);
            Assert.AreEqual(1, domain.Results.Length);
            Assert.AreEqual("True", domain.Results[0].Result?.IsDb);
        }

        [TestMethod]
        public void DomainAPIMulti()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var domain = client.GetDomain("builtwith.com", "overstock.com");
            Assert.IsNotNull(domain);
            Assert.IsNotNull(domain.Results);
            Assert.AreEqual(2, domain.Results.Length);
            Assert.AreEqual("True", domain.Results[0].Result?.IsDb);
            Assert.AreEqual("True", domain.Results[1].Result?.IsDb);
        }

        [TestMethod]
        public async Task DomainAPIAsync()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var domain = await client.GetDomainAsync("builtwith.com");
            Assert.IsNotNull(domain);
            Assert.IsNotNull(domain.Results);
            Assert.AreEqual(1, domain.Results.Length);
        }

        [TestMethod]
        public void FreeAPI()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var result = client.GetFree("builtwith.com");
            Assert.IsNotNull(result);
            Assert.AreEqual("builtwith.com", result.Domain);
            Assert.IsNotNull(result.Groups);
            Assert.IsTrue(result.Groups.Length > 0);
        }

        [TestMethod]
        public void RelationshipsAPI()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var result = client.GetRelationships("builtwith.com");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Relationships);
            Assert.IsTrue(result.Relationships.Length > 0);
        }

        [TestMethod]
        public void KeywordsAPI()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var result = client.GetKeywords("builtwith.com");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Keywords);
            Assert.IsTrue(result.Keywords.Length > 0);
        }

        [TestMethod]
        public void TrendsAPI()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var result = client.GetTrends("Shopify");
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Tech);
            Assert.AreEqual("Shopify", result.Tech.Name);
        }

        [TestMethod]
        public void CompanyToUrlAPI()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var result = client.GetCompanyToUrl("BuiltWith");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }

        [TestMethod]
        public void RedirectsAPI()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var result = client.GetRedirects("builtwith.com");
            Assert.IsNotNull(result);
            Assert.AreEqual("builtwith.com", result.Lookup);
        }

        [TestMethod]
        public void TrustAPI()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var result = client.GetTrust("builtwith.com");
            Assert.IsNotNull(result);
            Assert.AreEqual("builtwith.com", result.Domain);
            Assert.IsNotNull(result.Assessment);
        }

        [TestMethod]
        public void RecommendationsAPI()
        {
            using var client = new BuiltWith.BuiltWithClient(APIKEY);
            var result = client.GetRecommendations("builtwith.com");
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Length > 0);
        }
    }
}
