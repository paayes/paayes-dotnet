namespace PaayesTests.Identity
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes.Identity;
    using Xunit;

    public class VerificationReportServiceTest : BasePaayesTest
    {
        private const string VerificationReportId = "vr_123";

        private readonly VerificationReportService service;
        private readonly VerificationReportListOptions listOptions;

        public VerificationReportServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new VerificationReportService(this.PaayesClient);

            this.listOptions = new VerificationReportListOptions
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Get()
        {
            var verificationReport = this.service.Get(VerificationReportId);
            this.AssertRequest(HttpMethod.Get, "/v1/identity/verification_reports/vr_123");
            Assert.NotNull(verificationReport);
        }

        [Fact]
        public async Task GetAsync()
        {
            var verificationReport = await this.service.GetAsync(VerificationReportId);
            this.AssertRequest(HttpMethod.Get, "/v1/identity/verification_reports/vr_123");
            Assert.NotNull(verificationReport);
        }

        [Fact]
        public void List()
        {
            var verificationReports = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/identity/verification_reports");
            Assert.NotNull(verificationReports);
        }

        [Fact]
        public async Task ListAsync()
        {
            var verificationReports = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/identity/verification_reports");
            Assert.NotNull(verificationReports);
        }
    }
}
