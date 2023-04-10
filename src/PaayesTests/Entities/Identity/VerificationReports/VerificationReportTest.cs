namespace PaayesTests.Identity
{
    using Newtonsoft.Json;
    using Paayes.Identity;
    using Xunit;

    public class VerificationReportTest : BasePaayesTest
    {
        public VerificationReportTest(PaayesMockFixture paayesMockFixture)
            : base(paayesMockFixture)
        {
        }

        [Fact]
        public void Deserialize()
        {
            string json = this.GetFixture("/v1/identity/verification_reports/vr_123");
            var verificationReport = JsonConvert.DeserializeObject<VerificationReport>(json);
            Assert.NotNull(verificationReport);
            Assert.IsType<VerificationReport>(verificationReport);
            Assert.NotNull(verificationReport.Id);
            Assert.Equal("identity.verification_report", verificationReport.Object);
        }
    }
}
