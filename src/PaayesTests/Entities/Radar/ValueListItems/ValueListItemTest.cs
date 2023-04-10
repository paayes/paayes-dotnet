namespace PaayesTests.Radar
{
    using Newtonsoft.Json;
    using Paayes.Radar;
    using Xunit;

    public class ValueListItemTest : BasePaayesTest
    {
        public ValueListItemTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/radar/value_list_items/rsli_123");
            var valueListItem = JsonConvert.DeserializeObject<ValueListItem>(json);
            Assert.NotNull(valueListItem);
            Assert.IsType<ValueListItem>(valueListItem);
            Assert.NotNull(valueListItem.Id);
            Assert.Equal("radar.value_list_item", valueListItem.Object);
        }
    }
}
