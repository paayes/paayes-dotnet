namespace PaayesTests.Radar
{
    using Newtonsoft.Json;
    using Paayes.Radar;
    using Xunit;

    public class ValueListTest : BasePaayesTest
    {
        public ValueListTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/radar/value_lists/rsl_123");
            var valueList = JsonConvert.DeserializeObject<ValueList>(json);
            Assert.NotNull(valueList);
            Assert.IsType<ValueList>(valueList);
            Assert.NotNull(valueList.Id);
            Assert.Equal("radar.value_list", valueList.Object);
        }
    }
}
