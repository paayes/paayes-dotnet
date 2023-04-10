namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class WebhookEndpointTest : BasePaayesTest
    {
        public WebhookEndpointTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/webhook_endpoints/we_123");
            var endpoint = JsonConvert.DeserializeObject<WebhookEndpoint>(json);
            Assert.NotNull(endpoint);
            Assert.IsType<WebhookEndpoint>(endpoint);
            Assert.NotNull(endpoint.Id);
            Assert.Equal("webhook_endpoint", endpoint.Object);
        }
    }
}
