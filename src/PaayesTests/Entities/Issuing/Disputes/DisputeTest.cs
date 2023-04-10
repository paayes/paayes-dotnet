namespace PaayesTests.Issuing
{
    using Newtonsoft.Json;
    using Paayes.Issuing;
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
            string json = this.GetFixture("/v1/issuing/disputes/idp_123");
            var dispute = JsonConvert.DeserializeObject<Dispute>(json);
            Assert.NotNull(dispute);
            Assert.IsType<Dispute>(dispute);
            Assert.NotNull(dispute.Id);
            Assert.Equal("issuing.dispute", dispute.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "transaction",
            };

            string json = this.GetFixture("/v1/issuing/disputes/idp_123", expansions);
            var dispute = JsonConvert.DeserializeObject<Dispute>(json);
            Assert.NotNull(dispute);
            Assert.IsType<Dispute>(dispute);
            Assert.NotNull(dispute.Id);
            Assert.Equal("issuing.dispute", dispute.Object);

            Assert.NotNull(dispute.Transaction);
            Assert.Equal("issuing.transaction", dispute.Transaction.Object);
        }
    }
}
