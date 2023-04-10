namespace PaayesTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class AccountLinkServiceTest : BasePaayesTest
    {
        private readonly AccountLinkService service;
        private readonly AccountLinkCreateOptions createOptions;

        public AccountLinkServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new AccountLinkService(this.PaayesClient);

            this.createOptions = new AccountLinkCreateOptions
            {
                Account = "acct_123",
                Collect = "eventually_due",
                RefreshUrl = "https://paayes.com/refresh",
                ReturnUrl = "https://paayes.com/return",
                Type = "account_onboarding",
            };
        }

        [Fact]
        public void Create()
        {
            var accountLink = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/account_links");
            Assert.NotNull(accountLink);
            Assert.Equal("account_link", accountLink.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var accountLink = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/account_links");
            Assert.NotNull(accountLink);
            Assert.Equal("account_link", accountLink.Object);
        }
    }
}
