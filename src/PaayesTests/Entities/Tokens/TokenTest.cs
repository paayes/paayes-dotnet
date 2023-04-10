namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class TokenTest : BasePaayesTest
    {
        public TokenTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/tokens/tok_123");
            var token = JsonConvert.DeserializeObject<Token>(json);
            Assert.NotNull(token);
            Assert.IsType<Token>(token);
            Assert.NotNull(token.Id);
            Assert.Equal("token", token.Object);
        }
    }
}
