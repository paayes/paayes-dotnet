namespace PaayesTests.Issuing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes.Issuing;
    using Xunit;

    public class IssuingDisputeServiceTest : BasePaayesTest
    {
        private const string DisputeId = "idp_123";

        private readonly DisputeService service;
        private readonly DisputeCreateOptions createOptions;
        private readonly DisputeSubmitOptions submitOptions;
        private readonly DisputeUpdateOptions updateOptions;
        private readonly DisputeListOptions listOptions;

        public IssuingDisputeServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new DisputeService(this.PaayesClient);

            this.createOptions = new DisputeCreateOptions
            {
                Evidence = new DisputeEvidenceOptions
                {
                    NotReceived = new DisputeEvidenceNotReceivedOptions
                    {
                        AdditionalDocumentation = "file_123",
                        ExpectedAt = DateTime.Now,
                        Explanation = "Dispute explanation",
                        ProductDescription = "Product description",
                        ProductType = "merchandise",
                    },
                    Reason = "not_received",
                },
                Transaction = "ipi_123",
            };

            this.submitOptions = new DisputeSubmitOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    { "key", "value" },
                },
            };

            this.updateOptions = new DisputeUpdateOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new DisputeListOptions
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Create()
        {
            var dispute = this.service.Create(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes");
            Assert.NotNull(dispute);
        }

        [Fact]
        public async Task CreateAsync()
        {
            var dispute = await this.service.CreateAsync(this.createOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes");
            Assert.NotNull(dispute);
        }

        [Fact]
        public void Get()
        {
            var dispute = this.service.Get(DisputeId);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/disputes/idp_123");
            Assert.NotNull(dispute);
        }

        [Fact]
        public async Task GetAsync()
        {
            var dispute = await this.service.GetAsync(DisputeId);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/disputes/idp_123");
            Assert.NotNull(dispute);
        }

        [Fact]
        public void List()
        {
            var disputes = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/disputes");
            Assert.NotNull(disputes);
        }

        [Fact]
        public async Task ListAsync()
        {
            var disputes = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/disputes");
            Assert.NotNull(disputes);
        }

        [Fact]
        public void ListAutoPaging()
        {
            var dispute = this.service.ListAutoPaging(this.listOptions).First();
            Assert.NotNull(dispute);
            Assert.Equal("issuing.dispute", dispute.Object);
        }

        [Fact]
        public async Task ListAutoPagingAsync()
        {
            var dispute = await this.service.ListAutoPagingAsync(this.listOptions).FirstAsync();
            Assert.NotNull(dispute);
            Assert.Equal("issuing.dispute", dispute.Object);
        }

        [Fact]
        public void Submit()
        {
            var dispute = this.service.Submit(DisputeId, this.submitOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes/idp_123/submit");
            Assert.NotNull(dispute);
        }

        [Fact]
        public async Task SubmitAsync()
        {
            var dispute = await this.service.SubmitAsync(DisputeId, this.submitOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes/idp_123/submit");
            Assert.NotNull(dispute);
        }

        [Fact]
        public void Update()
        {
            var dispute = this.service.Update(DisputeId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes/idp_123");
            Assert.NotNull(dispute);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var dispute = await this.service.UpdateAsync(DisputeId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/disputes/idp_123");
            Assert.NotNull(dispute);
        }
    }
}
