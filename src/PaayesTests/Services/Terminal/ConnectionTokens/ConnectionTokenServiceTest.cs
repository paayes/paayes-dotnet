namespace PaayesTests.Terminal
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes.Terminal;
    using Xunit;

    public class ConnectionTokenServiceTest : BasePaayesTest
    {
        private readonly ConnectionTokenService service;
        private readonly ConnectionTokenCreateOptions createOptions;

        public ConnectionTokenServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new ConnectionTokenService(this.PaayesClient);

            this.createOptions = new ConnectionTokenCreateOptions
            {
            };
        }

        [Fact]
        public void Create()
        {
            var connectionToken = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/terminal/connection_tokens");
            Assert.NotNull(connectionToken);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var connectionToken = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/terminal/connection_tokens");
            Assert.NotNull(connectionToken);
        }
    }
}
