namespace PaayesTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class MandateServiceTest : BasePaayesTest
    {
        private const string MandateId = "mandate_123";

        private readonly MandateService service;

        public MandateServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new MandateService(this.PaayesClient);
        }

        [Fact]
        public void Get()
        {
            var mandate = this.service.Get(MandateId);
            this.AssertRequest(HttpMethod.Get, "/v1/mandates/mandate_123");
            Assert.NotNull(mandate);
            Assert.Equal("mandate", mandate.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var mandate = await this.service.GetAsync(MandateId);
            this.AssertRequest(HttpMethod.Get, "/v1/mandates/mandate_123");
            Assert.NotNull(mandate);
            Assert.Equal("mandate", mandate.Object);
        }
    }
}
