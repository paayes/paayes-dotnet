namespace PaayesTests.Terminal
{
    using Newtonsoft.Json;
    using Paayes.Terminal;
    using Xunit;

    public class ReaderTest : BasePaayesTest
    {
        public ReaderTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/terminal/readers/ds_123");
            var reader = JsonConvert.DeserializeObject<Reader>(json);
            Assert.NotNull(reader);
            Assert.IsType<Reader>(reader);
            Assert.NotNull(reader.Id);
            Assert.Equal("terminal.reader", reader.Object);
        }
    }
}
