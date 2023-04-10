namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class PlanTest : BasePaayesTest
    {
        public PlanTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/plans/plan_123");
            var plan = JsonConvert.DeserializeObject<Plan>(json);
            Assert.NotNull(plan);
            Assert.IsType<Plan>(plan);
            Assert.NotNull(plan.Id);
            Assert.Equal("plan", plan.Object);
        }

        [Fact]
        public void DeserializeWithExpansions()
        {
            string[] expansions =
            {
              "product",
            };

            string json = this.GetFixture("/v1/plans/plan_123", expansions);
            var plan = JsonConvert.DeserializeObject<Plan>(json);
            Assert.NotNull(plan);
            Assert.IsType<Plan>(plan);
            Assert.NotNull(plan.Id);
            Assert.Equal("plan", plan.Object);

            Assert.NotNull(plan.Product);
            Assert.Equal("product", plan.Product.Object);
        }
    }
}
