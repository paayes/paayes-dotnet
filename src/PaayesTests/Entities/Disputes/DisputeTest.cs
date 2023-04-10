namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class DisputeTest : BasePaayesTest
    {
        public DisputeTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/disputes/dp_123");
            var dispute = JsonConvert.DeserializeObject<Dispute>(json);
            Assert.NotNull(dispute);
            Assert.IsType<Dispute>(dispute);
            Assert.NotNull(dispute.Id);
            Assert.Equal("dispute", dispute.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "charge",
              "payment_intent",
            };

            string json = this.GetFixture("/v1/disputes/dp_123", expansions);
            var dispute = JsonConvert.DeserializeObject<Dispute>(json);
            Assert.NotNull(dispute);
            Assert.IsType<Dispute>(dispute);
            Assert.NotNull(dispute.Id);
            Assert.Equal("dispute", dispute.Object);

            Assert.NotNull(dispute.Charge);
            Assert.Equal("charge", dispute.Charge.Object);

            Assert.NotNull(dispute.PaymentIntent);
            Assert.Equal("payment_intent", dispute.PaymentIntent.Object);
        }
    }
}
