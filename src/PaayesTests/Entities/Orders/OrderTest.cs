namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class OrderTest : BasePaayesTest
    {
        public OrderTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/orders/or_123");
            var order = JsonConvert.DeserializeObject<Order>(json);
            Assert.NotNull(order);
            Assert.IsType<Order>(order);
            Assert.NotNull(order.Id);
            Assert.Equal("order", order.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "charge",
              "customer",
            };

            string json = this.GetFixture("/v1/orders/or_123", expansions);
            var order = JsonConvert.DeserializeObject<Order>(json);
            Assert.NotNull(order);
            Assert.IsType<Order>(order);
            Assert.NotNull(order.Id);
            Assert.Equal("order", order.Object);

            Assert.NotNull(order.Charge);
            Assert.Equal("charge", order.Charge.Object);

            Assert.NotNull(order.Customer);
            Assert.Equal("customer", order.Customer.Object);
        }
    }
}
