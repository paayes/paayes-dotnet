namespace PaayesTests.BillingPortal
{
    using Newtonsoft.Json;
    using Paayes;
    using Paayes.BillingPortal;
    using Xunit;

    public class SessionTest : BasePaayesTest
    {
        public SessionTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            var json = GetResourceAsString("api_fixtures.billing_portal.session.json");
            var session = JsonConvert.DeserializeObject<Session>(json);
            Assert.NotNull(session);
            Assert.IsType<Session>(session);
            Assert.NotNull(session.Id);
            Assert.Equal("billing_portal.session", session.Object);
        }
    }
}
