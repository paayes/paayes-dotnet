namespace PaayesTests
{
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class DiscountServiceTest : BasePaayesTest
    {
        private readonly DiscountService service;

        public DiscountServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new DiscountService(this.PaayesClient);
        }

        [Fact]
        public void DeleteCustomerDiscount()
        {
            var deleted = this.service.DeleteCustomerDiscount("cus_123");
            this.AssertRequest(HttpMethod.Delete, "/v1/customers/cus_123/discount");
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteCustomerDiscountAsync()
        {
            var deleted = await this.service.DeleteCustomerDiscountAsync("cus_123");
            this.AssertRequest(HttpMethod.Delete, "/v1/customers/cus_123/discount");
            Assert.NotNull(deleted);
        }

        [Fact]
        public void DeleteSubscriptionDiscount()
        {
            var deleted = this.service.DeleteSubscriptionDiscount("sub_123");
            this.AssertRequest(HttpMethod.Delete, "/v1/subscriptions/sub_123/discount");
            Assert.NotNull(deleted);
        }

        [Fact]
        public async Task DeleteSubscriptionDiscountAsync()
        {
            var deleted = await this.service.DeleteSubscriptionDiscountAsync("sub_123");
            this.AssertRequest(HttpMethod.Delete, "/v1/subscriptions/sub_123/discount");
            Assert.NotNull(deleted);
        }
    }
}
