namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class TaxCodeTest : BasePaayesTest
    {
        public TaxCodeTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/tax_codes/txcd_123");
            var taxCode = JsonConvert.DeserializeObject<TaxCode>(json);
            Assert.NotNull(taxCode);
            Assert.IsType<TaxCode>(taxCode);
            Assert.NotNull(taxCode.Id);
            Assert.Equal("tax_code", taxCode.Object);
        }
    }
}
