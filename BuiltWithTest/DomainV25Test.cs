using System.Text.Json;
using BuiltWith.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BuiltWithTest
{
    [TestClass]
    public class DomainV25Test
    {
        [TestMethod]
        public void PreservesConfidenceAndRegistrationNumbers()
        {
            const string json = "{\"Results\":[{\"Result\":{\"Paths\":[{\"Technologies\":[{\"confidence\":0},{\"confidence\":0.75},{\"confidence\":1}]}]},\"Meta\":{\"company_reg\":[{\"type\":\"ABN\",\"number\":\"001234\"}]}}]}";
            var result = JsonSerializer.Deserialize<DomainApiResponse>(json)!.Results![0];
            var technologies = result.Result!.Paths![0].Technologies!;
            Assert.AreEqual(0d, technologies[0].Confidence);
            Assert.AreEqual(0.75d, technologies[1].Confidence);
            Assert.AreEqual(1d, technologies[2].Confidence);
            Assert.AreEqual("ABN", result.Meta!.CompanyRegistrations[0].Type);
            Assert.AreEqual("001234", result.Meta.CompanyRegistrations[0].Number);
        }

        [TestMethod]
        public void SupportsEmptyMetadataAndOlderResponses()
        {
            Assert.AreEqual(0, JsonSerializer.Deserialize<DomainMeta>("{\"company_reg\":[]}")!.CompanyRegistrations.Length);
            Assert.AreEqual(0, JsonSerializer.Deserialize<DomainMeta>("{}")!.CompanyRegistrations.Length);
            Assert.IsNull(JsonSerializer.Deserialize<DomainTechnology>("{}")!.Confidence);
        }
    }
}
