namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class CountrySpecTest : BasePaayesTest
    {
        public CountrySpecTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/country_specs/US");
            var countrySpec = JsonConvert.DeserializeObject<CountrySpec>(json);
            Assert.NotNull(countrySpec);
            Assert.IsType<CountrySpec>(countrySpec);
            Assert.NotNull(countrySpec.Id);
            Assert.Equal("country_spec", countrySpec.Object);
        }
    }
}
