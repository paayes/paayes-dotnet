namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class TopupTest : BasePaayesTest
    {
        public TopupTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/topups/tu_123");
            var topup = JsonConvert.DeserializeObject<Topup>(json);
            Assert.NotNull(topup);
            Assert.IsType<Topup>(topup);
            Assert.NotNull(topup.Id);
            Assert.Equal("topup", topup.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "balance_transaction",
              "source",
            };

            string json = this.GetFixture("/v1/topups/tu_123", expansions);
            var topup = JsonConvert.DeserializeObject<Topup>(json);
            Assert.NotNull(topup);
            Assert.IsType<Topup>(topup);
            Assert.NotNull(topup.Id);
            Assert.Equal("topup", topup.Object);

            Assert.NotNull(topup.BalanceTransaction);
            Assert.Equal("balance_transaction", topup.BalanceTransaction.Object);

            Assert.NotNull(topup.Source);
            Assert.Equal("ach_debit", topup.Source.Type);
            Assert.Equal("source", topup.Source.Object);
        }
    }
}
