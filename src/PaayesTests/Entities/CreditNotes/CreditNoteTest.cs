namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class CreditNoteTest : BasePaayesTest
    {
        public CreditNoteTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/credit_notes/cn_123");
            var creditNote = JsonConvert.DeserializeObject<CreditNote>(json);
            Assert.NotNull(creditNote);
            Assert.IsType<CreditNote>(creditNote);
            Assert.NotNull(creditNote.Id);
            Assert.Equal("credit_note", creditNote.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "customer",
              "customer_balance_transaction",
              "invoice",
              "refund",
            };

            string json = this.GetFixture("/v1/credit_notes/cn_123456", expansions);
            var creditNote = JsonConvert.DeserializeObject<CreditNote>(json);
            Assert.NotNull(creditNote);
            Assert.IsType<CreditNote>(creditNote);
            Assert.NotNull(creditNote.Id);
            Assert.Equal("credit_note", creditNote.Object);

            Assert.NotNull(creditNote.Customer);
            Assert.Equal("customer", creditNote.Customer.Object);

            Assert.NotNull(creditNote.CustomerBalanceTransaction);
            Assert.Equal("customer_balance_transaction", creditNote.CustomerBalanceTransaction.Object);

            Assert.NotNull(creditNote.Invoice);
            Assert.Equal("invoice", creditNote.Invoice.Object);

            Assert.NotNull(creditNote.Refund);
            Assert.Equal("refund", creditNote.Refund.Object);
        }
    }
}
