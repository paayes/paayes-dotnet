namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class SubscriptionTest : BasePaayesTest
    {
        public SubscriptionTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/subscriptions/sub_123");
            var subscription = JsonConvert.DeserializeObject<Subscription>(json);
            Assert.NotNull(subscription);
            Assert.IsType<Subscription>(subscription);
            Assert.NotNull(subscription.Id);
            Assert.Equal("subscription", subscription.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "customer",
              "default_payment_method",
              "latest_invoice",
              "pending_setup_intent",
            };

            string json = this.GetFixture("/v1/subscriptions/sub_123", expansions);
            var subscription = JsonConvert.DeserializeObject<Subscription>(json);
            Assert.NotNull(subscription);
            Assert.IsType<Subscription>(subscription);
            Assert.NotNull(subscription.Id);
            Assert.Equal("subscription", subscription.Object);

            Assert.NotNull(subscription.Customer);
            Assert.Equal("customer", subscription.Customer.Object);

            Assert.NotNull(subscription.DefaultPaymentMethod);
            Assert.Equal("payment_method", subscription.DefaultPaymentMethod.Object);

            Assert.NotNull(subscription.LatestInvoice);
            Assert.Equal("invoice", subscription.LatestInvoice.Object);

            Assert.NotNull(subscription.PendingSetupIntent);
            Assert.Equal("setup_intent", subscription.PendingSetupIntent.Object);
        }
    }
}
