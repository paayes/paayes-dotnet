namespace PaayesTests.Issuing
{
    using Newtonsoft.Json;
    using Paayes.Issuing;
    using Xunit;

    public class TransactionTest : BasePaayesTest
    {
        public TransactionTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/issuing/transactions/ipi_123");
            var transaction = JsonConvert.DeserializeObject<Transaction>(json);
            Assert.NotNull(transaction);
            Assert.IsType<Transaction>(transaction);
            Assert.NotNull(transaction.Id);
            Assert.Equal("issuing.transaction", transaction.Object);
        }
    }
}
