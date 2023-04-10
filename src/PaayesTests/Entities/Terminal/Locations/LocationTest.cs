namespace PaayesTests.Terminal
{
    using Newtonsoft.Json;
    using Paayes.Terminal;
    using Xunit;

    public class LocationTest : BasePaayesTest
    {
        public LocationTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/terminal/locations/loc_123");
            var location = JsonConvert.DeserializeObject<Location>(json);
            Assert.NotNull(location);
            Assert.IsType<Location>(location);
            Assert.NotNull(location.Id);
            Assert.Equal("terminal.location", location.Object);
        }
    }
}
