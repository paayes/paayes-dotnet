namespace PaayesTests.Issuing
{
    using Newtonsoft.Json;
    using Paayes.Issuing;
    using Xunit;

    public class CardholderTest : BasePaayesTest
    {
        public CardholderTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/issuing/cardholders/ich_123");
            var cardholder = JsonConvert.DeserializeObject<Cardholder>(json);
            Assert.NotNull(cardholder);
            Assert.IsType<Cardholder>(cardholder);
            Assert.NotNull(cardholder.Id);
            Assert.Equal("issuing.cardholder", cardholder.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "individual.verification.document.back",
              "individual.verification.document.front",
            };

            string json = this.GetFixture("/v1/issuing/cardholders/ich_123", expansions);
            var cardholder = JsonConvert.DeserializeObject<Cardholder>(json);
            Assert.NotNull(cardholder);
            Assert.IsType<Cardholder>(cardholder);
            Assert.NotNull(cardholder.Id);
            Assert.Equal("issuing.cardholder", cardholder.Object);

            Assert.NotNull(cardholder.Individual.Verification.Document.Back);
            Assert.Equal("file", cardholder.Individual.Verification.Document.Back.Object);

            Assert.NotNull(cardholder.Individual.Verification.Document.Front);
            Assert.Equal("file", cardholder.Individual.Verification.Document.Front.Object);
        }
    }
}