namespace PaayesTests
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class UsageRecordServiceTest : BasePaayesTest
    {
        private readonly UsageRecordService service;
        private readonly UsageRecordCreateOptions createOptions;

        public UsageRecordServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new UsageRecordService(this.PaayesClient);

            this.createOptions = new UsageRecordCreateOptions
            {
                Quantity = 10,
                Timestamp = DateTime.Now,
            };
        }

        [Fact]
        public void Create()
        {
            var plan = this.service.Create("si_123", this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/subscription_items/si_123/usage_records");
            Assert.NotNull(plan);
            Assert.Equal("usage_record", plan.Object);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var plan = await this.service.CreateAsync("si_123", this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/subscription_items/si_123/usage_records");
            Assert.NotNull(plan);
            Assert.Equal("usage_record", plan.Object);
        }
    }
}
