namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class DiscountTest : BasePaayesTest
    {
        public DiscountTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            var json = GetResourceAsString("api_fixtures.discount.json");
            var discount = JsonConvert.DeserializeObject<Discount>(json);

            Assert.NotNull(discount);
            Assert.Equal("discount", discount.Object);
            Assert.NotNull(discount.Coupon);
            Assert.Equal("coupon", discount.Coupon.Object);
        }
    }
}
