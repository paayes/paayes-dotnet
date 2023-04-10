namespace PaayesTests.Issuing
{
    using Newtonsoft.Json;
    using Paayes.Issuing;
    using Xunit;

    public class CardTest : BasePaayesTest
    {
        public CardTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/issuing/cards/ic_123");
            var card = JsonConvert.DeserializeObject<Card>(json);
            Assert.NotNull(card);
            Assert.IsType<Card>(card);
            Assert.NotNull(card.Id);
            Assert.Equal("issuing.card", card.Object);

            // Assert.NotNull(card.Cardholder);
            // Assert.Equal("issuing.cardholder", card.Cardholder.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "replacement_for",
            };
            string json = this.GetFixture("/v1/issuing/cards/ic_123", expansions);
            var card = JsonConvert.DeserializeObject<Card>(json);
            Assert.NotNull(card);
            Assert.IsType<Card>(card);
            Assert.NotNull(card.Id);
            Assert.Equal("issuing.card", card.Object);

            Assert.NotNull(card.ReplacementFor);
            Assert.Equal("issuing.card", card.ReplacementFor.Object);
        }
    }
}
