namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class ApplePayDomainTest : BasePaayesTest
    {
        public ApplePayDomainTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/apple_pay/domains/apwc_123");
            var domain = JsonConvert.DeserializeObject<ApplePayDomain>(json);
            Assert.NotNull(domain);
            Assert.IsType<ApplePayDomain>(domain);
            Assert.NotNull(domain.Id);
            Assert.Equal("apple_pay_domain", domain.Object);
        }
    }
}
