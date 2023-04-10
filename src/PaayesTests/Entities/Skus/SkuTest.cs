namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class SkuTest : BasePaayesTest
    {
        public SkuTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/skus/sku_123");
            var sku = JsonConvert.DeserializeObject<Sku>(json);
            Assert.NotNull(sku);
            Assert.IsType<Sku>(sku);
            Assert.NotNull(sku.Id);
            Assert.Equal("sku", sku.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "product",
            };

            string json = this.GetFixture("/v1/skus/sku_123", expansions);
            var sku = JsonConvert.DeserializeObject<Sku>(json);
            Assert.NotNull(sku);
            Assert.IsType<Sku>(sku);
            Assert.NotNull(sku.Id);
            Assert.Equal("sku", sku.Object);

            Assert.NotNull(sku.Product);
            Assert.Equal("product", sku.Product.Object);
        }
    }
}
