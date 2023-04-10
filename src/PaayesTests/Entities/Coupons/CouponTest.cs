namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class CouponTest : BasePaayesTest
    {
        public CouponTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/coupons/co_123");
            var coupon = JsonConvert.DeserializeObject<Coupon>(json);
            Assert.NotNull(coupon);
            Assert.IsType<Coupon>(coupon);
            Assert.NotNull(coupon.Id);
            Assert.Equal("coupon", coupon.Object);
        }
    }
}
