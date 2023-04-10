namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class TaxIdTest : BasePaayesTest
    {
        public TaxIdTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/customers/cus_123/tax_ids/txi_123");
            var taxId = JsonConvert.DeserializeObject<TaxId>(json);
            Assert.NotNull(taxId);
            Assert.IsType<TaxId>(taxId);
            Assert.NotNull(taxId.Id);
            Assert.Equal("tax_id", taxId.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "customer",
            };

            string json = this.GetFixture("/v1/customers/cus_123/tax_ids/txi_123", expansions);
            var taxId = JsonConvert.DeserializeObject<TaxId>(json);
            Assert.NotNull(taxId);
            Assert.IsType<TaxId>(taxId);
            Assert.NotNull(taxId.Id);
            Assert.Equal("tax_id", taxId.Object);

            Assert.NotNull(taxId.Customer);
            Assert.Equal("customer", taxId.Customer.Object);
        }
    }
}
