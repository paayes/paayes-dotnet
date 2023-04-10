namespace PaayesTests
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class TaxCodeServiceTest : BasePaayesTest
    {
        private const string ScheduleId = "sub_sched_123";

        private readonly TaxCodeService service;
        private readonly TaxCodeListOptions listOptions;

        public TaxCodeServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new TaxCodeService(this.PaayesClient);

            this.listOptions = new TaxCodeListOptions
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Get()
        {
            var subscription = this.service.Get(ScheduleId);
            this.AssertRequest(HttpMethod.Get, "/v1/tax_codes/sub_sched_123");
            Assert.NotNull(subscription);
            Assert.Equal("tax_code", subscription.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var subscription = await this.service.GetAsync(ScheduleId);
            this.AssertRequest(HttpMethod.Get, "/v1/tax_codes/sub_sched_123");
            Assert.NotNull(subscription);
            Assert.Equal("tax_code", subscription.Object);
        }

        [Fact]
        public void List()
        {
            var taxCodes = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/tax_codes");
            Assert.NotNull(taxCodes);
            Assert.Equal("list", taxCodes.Object);
            Assert.Single(taxCodes.Data);
            Assert.Equal("tax_code", taxCodes.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var taxCodes = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/tax_codes");
            Assert.NotNull(taxCodes);
            Assert.Equal("list", taxCodes.Object);
            Assert.Single(taxCodes.Data);
            Assert.Equal("tax_code", taxCodes.Data[0].Object);
        }
    }
}
