namespace PaayesTests
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes;
    using Xunit;

    public class SourceTransactionServiceTest : BasePaayesTest
    {
        private const string SourceId = "src_123";

        private readonly SourceTransactionService service;
        private readonly SourceTransactionsListOptions listOptions;

        public SourceTransactionServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new SourceTransactionService(this.PaayesClient);

            this.listOptions = new SourceTransactionsListOptions
            {
                Limit = 1,
            };
        }

        [Fact]
        public void List()
        {
            var sourceTransactions = this.service.List(SourceId, this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/sources/src_123/source_transactions");
            Assert.NotNull(sourceTransactions);
            Assert.Equal("list", sourceTransactions.Object);
            Assert.Single(sourceTransactions.Data);
            Assert.Equal("source_transaction", sourceTransactions.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var sourceTransactions = await this.service.ListAsync(SourceId, this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/sources/src_123/source_transactions");
            Assert.NotNull(sourceTransactions);
            Assert.Equal("list", sourceTransactions.Object);
            Assert.Single(sourceTransactions.Data);
            Assert.Equal("source_transaction", sourceTransactions.Data[0].Object);
        }

        [Fact]
        public void ListAutoPaging()
        {
            var sourceTransaction = this.service.ListAutoPaging(SourceId, this.listOptions).First();
            Assert.NotNull(sourceTransaction);
            Assert.Equal("source_transaction", sourceTransaction.Object);
        }

        [Fact]
        public async Task ListAutoPagingAsync()
        {
            var sourceTransaction = await this.service.ListAutoPagingAsync(SourceId, this.listOptions).FirstAsync();
            Assert.NotNull(sourceTransaction);
            Assert.Equal("source_transaction", sourceTransaction.Object);
        }
    }
}
