namespace PaayesTests.Terminal
{
    using Newtonsoft.Json;
    using Paayes.Terminal;
    using Xunit;

    public class ConnectionTokenTest : BasePaayesTest
    {
        public ConnectionTokenTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            var json = GetResourceAsString("api_fixtures.connection_token.json");
            var connectionToken = JsonConvert.DeserializeObject<ConnectionToken>(json);
            Assert.NotNull(connectionToken);
            Assert.IsType<ConnectionToken>(connectionToken);
            Assert.NotNull(connectionToken.Secret);
            Assert.Equal("terminal.connection_token", connectionToken.Object);
        }
    }
}
