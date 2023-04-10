namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class PriceTest : BasePaayesTest
    {
        public PriceTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/prices/price_123");
            var price = JsonConvert.DeserializeObject<Price>(json);
            Assert.NotNull(price);
            Assert.IsType<Price>(price);
            Assert.NotNull(price.Id);
            Assert.Equal("price", price.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "product",
            };

            string json = this.GetFixture("/v1/prices/price_123", expansions);
            var price = JsonConvert.DeserializeObject<Price>(json);
            Assert.NotNull(price);
            Assert.IsType<Price>(price);
            Assert.NotNull(price.Id);
            Assert.Equal("price", price.Object);

            Assert.NotNull(price.Product);
            Assert.Equal("product", price.Product.Object);
        }
    }
}
