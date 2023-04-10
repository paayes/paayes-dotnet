namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class TaxRateTest : BasePaayesTest
    {
        public TaxRateTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/tax_rates/txr_123");
            var taxRate = JsonConvert.DeserializeObject<TaxRate>(json);
            Assert.NotNull(taxRate);
            Assert.IsType<TaxRate>(taxRate);
            Assert.NotNull(taxRate.Id);
            Assert.Equal("tax_rate", taxRate.Object);
        }
    }
}
