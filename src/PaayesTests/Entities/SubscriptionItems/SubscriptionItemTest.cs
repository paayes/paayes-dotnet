namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class SubscriptionItemTest : BasePaayesTest
    {
        public SubscriptionItemTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/subscription_items/si_123");
            var subscriptionItem = JsonConvert.DeserializeObject<SubscriptionItem>(json);
            Assert.NotNull(subscriptionItem);
            Assert.IsType<SubscriptionItem>(subscriptionItem);
            Assert.NotNull(subscriptionItem.Id);
            Assert.Equal("subscription_item", subscriptionItem.Object);
        }
    }
}
