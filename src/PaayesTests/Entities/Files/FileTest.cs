namespace PaayesTests
{
    using Newtonsoft.Json;
    using Paayes;
    using Xunit;

    public class FileTest : BasePaayesTest
    {
        public FileTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/files/file_123");
            var file = JsonConvert.DeserializeObject<File>(json);
            Assert.NotNull(file);
            Assert.IsType<File>(file);
            Assert.NotNull(file.Id);
            Assert.Equal("file", file.Object);
        }
    }
}
