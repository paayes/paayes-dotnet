namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class CapabilityTest : BasePaayesTest
    {
        public CapabilityTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/accounts/acct_123/capabilities/acap_123");
            var capability = JsonConvert.DeserializeObject<Capability>(json);
            Assert.NotNull(capability);
            Assert.IsType<Capability>(capability);
            Assert.NotNull(capability.Id);
            Assert.Equal("capability", capability.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "account",
            };

            string json = this.GetFixture("/v1/accounts/acct_123/capabilities/acap_123", expansions);
            var capability = JsonConvert.DeserializeObject<Capability>(json);
            Assert.NotNull(capability);
            Assert.IsType<Capability>(capability);
            Assert.NotNull(capability.Id);
            Assert.Equal("capability", capability.Object);

            Assert.NotNull(capability.Account);
            Assert.Equal("account", capability.Account.Object);
        }
    }
}
