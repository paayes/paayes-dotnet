namespace PaayesTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class LoginLinkServiceTest : BasePaayesTest
    {
        private const string AccountId = "acct_123";

        private readonly LoginLinkService service;
        private readonly LoginLinkCreateOptions createOptions;

        public LoginLinkServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new LoginLinkService(this.PaayesClient);

            this.createOptions = new LoginLinkCreateOptions
            {
                RedirectUrl = "https://paayes.com/redirect?param=value",
            };
        }

        [Fact]
        public void Create()
        {
            var loginLink = this.service.Create(AccountId, this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/accounts/acct_123/login_links");
            Assert.NotNull(loginLink);
            Assert.Equal("login_link", loginLink.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var loginLink = await this.service.CreateAsync(AccountId, this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/accounts/acct_123/login_links");
            Assert.NotNull(loginLink);
            Assert.Equal("login_link", loginLink.Object);
        }
    }
}
