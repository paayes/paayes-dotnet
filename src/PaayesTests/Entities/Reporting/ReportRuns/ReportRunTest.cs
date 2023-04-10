namespace PaayesTests.Reporting
{
    using Newtonsoft.Json;
    using Paayes.Reporting;
    using Xunit;

    public class ReportRunTest : BasePaayesTest
    {
        public ReportRunTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/reporting/report_runs/frr_123");
            var reportRun = JsonConvert.DeserializeObject<ReportRun>(json);
            Assert.NotNull(reportRun);
            Assert.IsType<ReportRun>(reportRun);
            Assert.NotNull(reportRun.Id);
            Assert.Equal("reporting.report_run", reportRun.Object);
        }
    }
}
