namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class EphemeralKeyTest : BasePaayesTest
    {
        public EphemeralKeyTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            var json = GetResourceAsString("api_fixtures.ephemeral_key.json");
            var ephemeralKey = JsonConvert.DeserializeObject<EphemeralKey>(json);

            Assert.NotNull(ephemeralKey);
            Assert.NotNull(ephemeralKey.Id);
            Assert.Equal("ephemeral_key", ephemeralKey.Object);
        }
    }
}
