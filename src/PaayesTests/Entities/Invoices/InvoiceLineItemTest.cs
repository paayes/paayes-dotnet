namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class InvoiceLineItemTest : BasePaayesTest
    {
        public InvoiceLineItemTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/invoices/in_123/lines");
            var lineItems = JsonConvert.DeserializeObject<PaayesList<InvoiceLineItem>>(json);
            Assert.NotNull(lineItems);

            InvoiceLineItem lineItem = lineItems.Data[0];
            Assert.NotNull(lineItem);
            Assert.IsType<InvoiceLineItem>(lineItem);
            Assert.NotNull(lineItem.Id);
            Assert.Equal("line_item", lineItem.Object);
        }
    }
}
