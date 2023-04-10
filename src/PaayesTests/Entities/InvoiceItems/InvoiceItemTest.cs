namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class InvoiceItemTest : BasePaayesTest
    {
        public InvoiceItemTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/invoiceitems/ii_123");
            var invoiceItem = JsonConvert.DeserializeObject<InvoiceItem>(json);
            Assert.NotNull(invoiceItem);
            Assert.IsType<InvoiceItem>(invoiceItem);
            Assert.NotNull(invoiceItem.Id);
            Assert.Equal("invoiceitem", invoiceItem.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "customer",
              "invoice",
              "subscription",
            };

            string json = this.GetFixture("/v1/invoiceitems/ii_123", expansions);
            var invoiceItem = JsonConvert.DeserializeObject<InvoiceItem>(json);
            Assert.NotNull(invoiceItem);
            Assert.IsType<InvoiceItem>(invoiceItem);
            Assert.NotNull(invoiceItem.Id);
            Assert.Equal("invoiceitem", invoiceItem.Object);

            Assert.NotNull(invoiceItem.Customer);
            Assert.Equal("customer", invoiceItem.Customer.Object);

            Assert.NotNull(invoiceItem.Invoice);
            Assert.Equal("invoice", invoiceItem.Invoice.Object);

            Assert.NotNull(invoiceItem.Subscription);
            Assert.Equal("subscription", invoiceItem.Subscription.Object);
        }
    }
}
