namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class ProductTest : BasePaayesTest
    {
        public ProductTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/products/prod_123");
            var product = JsonConvert.DeserializeObject<Product>(json);

            Assert.NotNull(product);
            Assert.IsType<Product>(product);
            Assert.NotNull(product.Id);
            Assert.Equal("product", product.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "tax_code",
            };

            string json = this.GetFixture("/v1/products/prod_123", expansions);
            var product = JsonConvert.DeserializeObject<Product>(json);
            Assert.NotNull(product);
            Assert.IsType<Product>(product);
            Assert.NotNull(product.Id);
            Assert.Equal("product", product.Object);

            Assert.NotNull(product.TaxCode);
            Assert.Equal("tax_code", product.TaxCode.Object);
        }
    }
}
