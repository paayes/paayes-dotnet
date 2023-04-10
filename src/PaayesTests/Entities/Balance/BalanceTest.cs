namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class BalanceTest : BasePaayesTest
    {
        public BalanceTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/balance");
            var balance = JsonConvert.DeserializeObject<Balance>(json);
            Assert.NotNull(balance);
            Assert.IsType<Balance>(balance);
            Assert.Equal("balance", balance.Object);
        }
    }
}
