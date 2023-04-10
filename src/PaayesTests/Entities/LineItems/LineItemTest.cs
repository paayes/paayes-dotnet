namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class LineItemTest : BasePaayesTest
    {
        [Fact]
        public void Deserialize()
        {
            var json = GetResourceAsString("api_fixtures.line_item.json");
            var lineItem = JsonConvert.DeserializeObject<LineItem>(json);
            Assert.NotNull(lineItem);
            Assert.IsType<LineItem>(lineItem);
            Assert.Equal("item", lineItem.Object);
        }
    }
}
