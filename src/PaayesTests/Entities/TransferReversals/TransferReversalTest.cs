namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class TransferReversalTest : BasePaayesTest
    {
        public TransferReversalTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/transfers/tr_123/reversals/trr_123");
            var transferReversal = JsonConvert.DeserializeObject<TransferReversal>(json);
            Assert.NotNull(transferReversal);
            Assert.IsType<TransferReversal>(transferReversal);
            Assert.NotNull(transferReversal.Id);
            Assert.Equal("transfer_reversal", transferReversal.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "balance_transaction",
              "destination_payment_refund",
              "source_refund",
              "transfer",
            };

            string json = this.GetFixture("/v1/transfers/tr_123/reversals/trr_123", expansions);
            var transferReversal = JsonConvert.DeserializeObject<TransferReversal>(json);
            Assert.NotNull(transferReversal);
            Assert.IsType<TransferReversal>(transferReversal);
            Assert.NotNull(transferReversal.Id);
            Assert.Equal("transfer_reversal", transferReversal.Object);

            Assert.NotNull(transferReversal.BalanceTransaction);
            Assert.Equal("balance_transaction", transferReversal.BalanceTransaction.Object);

            Assert.NotNull(transferReversal.DestinationPaymentRefund);
            Assert.Equal("refund", transferReversal.DestinationPaymentRefund.Object);

            Assert.NotNull(transferReversal.SourceRefund);
            Assert.Equal("refund", transferReversal.SourceRefund.Object);

            Assert.NotNull(transferReversal.Transfer);
            Assert.Equal("transfer", transferReversal.Transfer.Object);
        }
    }
}
