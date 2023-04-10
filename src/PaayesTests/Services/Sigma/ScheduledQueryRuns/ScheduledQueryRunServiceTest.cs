namespace PaayesTests
{
    using System.Linq;
    using System.Net.Http;
    using System.Threading.Tasks;

    using Paayes.Sigma;
    using Xunit;

    public class ScheduledQueryRunServiceTest : BasePaayesTest
    {
        private const string ScheduledQueryId = "sqr_123";

        private readonly ScheduledQueryRunService service;
        private readonly ScheduledQueryRunListOptions listOptions;

        public ScheduledQueryRunServiceTest(
            PaayesMockFixture paayesMockFixture,
            MockHttpClientFixture mockHttpClientFixture)
            : base(paayesMockFixture, mockHttpClientFixture)
        {
            this.service = new ScheduledQueryRunService(this.PaayesClient);

            this.listOptions = new ScheduledQueryRunListOptions
            {
                Limit = 1,
            };
        }

        [Fact]
        public void Get()
        {
            var run = this.service.Get(ScheduledQueryId);
            this.AssertRequest(HttpMethod.Get, "/v1/sigma/scheduled_query_runs/sqr_123");
            Assert.NotNull(run);
            Assert.Equal("scheduled_query_run", run.Object);
        }

        [Fact]
        public async Task GetAsync()
        {
            var run = await this.service.GetAsync(ScheduledQueryId);
            this.AssertRequest(HttpMethod.Get, "/v1/sigma/scheduled_query_runs/sqr_123");
            Assert.NotNull(run);
            Assert.Equal("scheduled_query_run", run.Object);
        }

        [Fact]
        public void List()
        {
            var runs = this.service.List(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/sigma/scheduled_query_runs");
            Assert.NotNull(runs);
            Assert.Equal("list", runs.Object);
            Assert.Single(runs.Data);
            Assert.Equal("scheduled_query_run", runs.Data[0].Object);
        }

        [Fact]
        public async Task ListAsync()
        {
            var runs = await this.service.ListAsync(this.listOptions);
            this.AssertRequest(HttpMethod.Get, "/v1/sigma/scheduled_query_runs");
            Assert.NotNull(runs);
            Assert.Equal("list", runs.Object);
            Assert.Single(runs.Data);
            Assert.Equal("scheduled_query_run", runs.Data[0].Object);
        }

        [Fact]
        public void ListAutoPaging()
        {
            var run = this.service.ListAutoPaging(this.listOptions).First();
            Assert.NotNull(run);
            Assert.Equal("scheduled_query_run", run.Object);
        }

        [Fact]
        public async Task ListAutoPagingAsync()
        {
            var run = await this.service.ListAutoPagingAsync(this.listOptions).FirstAsync();
            Assert.NotNull(run);
            Assert.Equal("scheduled_query_run", run.Object);
        }
    }
}
