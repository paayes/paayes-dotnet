namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class SourceMandateNotificationTest : BasePaayesTest
    {
        public SourceMandateNotificationTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            var json = GetResourceAsString("api_fixtures.source_mandate_notification.json");
            var mandate = JsonConvert.DeserializeObject<SourceMandateNotification>(json);
            Assert.NotNull(mandate);
            Assert.IsType<SourceMandateNotification>(mandate);
            Assert.NotNull(mandate.Id);
            Assert.Equal("source_mandate_notification", mandate.Object);
        }
    }
}
