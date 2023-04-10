namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class UsageRecordTest : BasePaayesTest
    {
        public UsageRecordTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            var json = GetResourceAsString("api_fixtures.usage_record.json");
            var usageRecord = JsonConvert.DeserializeObject<UsageRecord>(json);

            Assert.NotNull(usageRecord);
            Assert.NotNull(usageRecord.Id);
            Assert.Equal("usage_record", usageRecord.Object);
        }
    }
}
