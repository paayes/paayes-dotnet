namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class SourceTest : BasePaayesTest
    {
        public SourceTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/sources/src_123");
            var source = JsonConvert.DeserializeObject<Source>(json);
            Assert.NotNull(source);
            Assert.IsType<Source>(source);
            Assert.NotNull(source.Id);
            Assert.Equal("source", source.Object);
        }
    }
}
