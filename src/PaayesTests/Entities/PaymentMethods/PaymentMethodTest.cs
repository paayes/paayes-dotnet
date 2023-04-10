namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class PaymentMethodTest : BasePaayesTest
    {
        public PaymentMethodTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/payment_methods/pm_123");
            var payment_method = JsonConvert.DeserializeObject<PaymentMethod>(json);
            Assert.NotNull(payment_method);
            Assert.IsType<PaymentMethod>(payment_method);
            Assert.NotNull(payment_method.Id);
            Assert.Equal("payment_method", payment_method.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "customer",
            };

            string json = this.GetFixture("/v1/payment_methods/pm_123", expansions);
            var payment_method = JsonConvert.DeserializeObject<PaymentMethod>(json);
            Assert.NotNull(payment_method);
            Assert.IsType<PaymentMethod>(payment_method);
            Assert.NotNull(payment_method.Id);
            Assert.Equal("payment_method", payment_method.Object);

            Assert.NotNull(payment_method.Customer);
            Assert.Equal("customer", payment_method.Customer.Object);
        }
    }
}
