namespace PaayesTests.Issuing
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes.Issuing;
    using Xunit;

    public class TransactionServiceTest : BasePaayesTest
    {
        private const string TransactionId = "ipi_123";

        private readonly TransactionService service;
        private readonly TransactionUpdateOptions updateOptions;
        private readonly TransactionListOptions listOptions;

        public TransactionServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new TransactionService(this.PaayesClient);

            this.updateOptions = new TransactionUpdateOptions
            {
                Metadata = new Dictionary<string, string>
                {
                    { "key", "value" },
                },
            };

            this.listOptions = new TransactionListOptions
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Get()
        {
            var transaction = this.service.Get(TransactionId);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/transactions/ipi_123");
            Assert.NotNull(transaction);
        }

        [Fact]
        public async Task GetAsync()
        {
            var transaction = await this.service.GetAsync(TransactionId);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/transactions/ipi_123");
            Assert.NotNull(transaction);
        }

        [Fact]
        public void List()
        {
            var transactions = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/transactions");
            Assert.NotNull(transactions);
        }

        [Fact]
        public async Task ListAsync()
        {
            var transactions = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/issuing/transactions");
            Assert.NotNull(transactions);
        }

        [Fact]
        public void ListAutoPaging()
        {
            var transaction = this.service.ListAutoPaging(this.listOptions).First();
            Assert.NotNull(transaction);
            Assert.Equal("issuing.transaction", transaction.Object);
        }

        [Fact]
        public async Task ListAutoPagingAsync()
        {
            var transaction = await this.service.ListAutoPagingAsync(this.listOptions).FirstAsync();
            Assert.NotNull(transaction);
            Assert.Equal("issuing.transaction", transaction.Object);
        }

        [Fact]
        public void Update()
        {
            var transaction = this.service.Update(TransactionId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/transactions/ipi_123");
            Assert.NotNull(transaction);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            var transaction = await this.service.UpdateAsync(TransactionId, this.updateOptions);
            this.AssertRequest(HttpMethod.Post, "/v1/issuing/transactions/ipi_123");
            Assert.NotNull(transaction);
        }
    }
}
