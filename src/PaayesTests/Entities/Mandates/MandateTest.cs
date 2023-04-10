namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class MandateTest : BasePaayesTest
    {
        public MandateTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/mandates/mandate_123");
            var mandate = JsonConvert.DeserializeObject<Mandate>(json);
            Assert.NotNull(mandate);
            Assert.IsType<Mandate>(mandate);
            Assert.NotNull(mandate.Id);
            Assert.Equal("mandate", mandate.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "payment_method",
            };

            string json = this.GetFixture("/v1/mandates/mandate_123", expansions);
            var mandate = JsonConvert.DeserializeObject<Mandate>(json);
            Assert.NotNull(mandate);
            Assert.IsType<Mandate>(mandate);
            Assert.NotNull(mandate.Id);
            Assert.Equal("mandate", mandate.Object);

            Assert.NotNull(mandate.PaymentMethod);
            Assert.Equal("payment_method", mandate.PaymentMethod.Object);
        }
    }
}
