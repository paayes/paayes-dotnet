namespace PaayesTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class BalanceServiceTest : BasePaayesTest
    {
        private readonly BalanceService service;

        public BalanceServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new BalanceService(this.PaayesClient);
        }

        [Fact]
        public void Get()
        {
            var balance = this.service.Get();
            this.AssertRequest(HttpMethod.Get, "/v1/balance");
            Assert.NotNull(balance);
            Assert.Equal("balance", balance.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var balance = await this.service.GetAsync();
            this.AssertRequest(HttpMethod.Get, "/v1/balance");
            Assert.NotNull(balance);
            Assert.Equal("balance", balance.Object);
        }
    }
}
