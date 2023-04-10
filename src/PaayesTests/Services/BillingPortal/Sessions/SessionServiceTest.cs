namespace PaayesTests.BillingPortal
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Paayes.BillingPortal;
    using Xunit;

    public class SessionServiceTest : BasePaayesTest
    {
        private const string SessionId = "pts_123";
        private readonly SessionService service;
        private readonly SessionCreateOptions createOptions;

        public SessionServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new SessionService(this.PaayesClient);

            this.createOptions = new SessionCreateOptions
            {
                Customer = "cus_123",
                ReturnUrl = "https://paayes.com/return",
            };
        }

        [Fact]
        public void Create()
        {
            var session = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/billing_portal/sessions");
            Assert.NotNull(session);
            Assert.Equal("billing_portal.session", session.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var session = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/billing_portal/sessions");
            Assert.NotNull(session);
            Assert.Equal("billing_portal.session", session.Object);
        }
    }
}
