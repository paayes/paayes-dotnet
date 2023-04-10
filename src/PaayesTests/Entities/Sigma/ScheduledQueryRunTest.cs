namespace PaayesTests.Sigma
{
    using Newtonsoft.Json;
    using Paayes.Sigma;
    using Xunit;

    public class ScheduledQueryRunTest : BasePaayesTest
    {
        public ScheduledQueryRunTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/sigma/scheduled_query_runs/sqr_123");
            var run = JsonConvert.DeserializeObject<ScheduledQueryRun>(json);
            Assert.NotNull(run);
            Assert.IsType<ScheduledQueryRun>(run);
            Assert.NotNull(run.Id);
            Assert.Equal("scheduled_query_run", run.Object);

            Assert.NotNull(run.File);
            Assert.Equal("file", run.File.Object);
        }
    }
}
