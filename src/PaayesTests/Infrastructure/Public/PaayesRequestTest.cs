namespace PaayesTests
{
    using System.Net.Http;
    using System.Threading.Tasks;
    using Paayes;
    using PaayesTests.Infrastructure.TestData;
    using Xunit;

    public class PaayesRequestTest : BasePaayesTest
    {
        private readonly IPaayesClient paayesClient;

        public PaayesRequestTest()
        {
            this.paayesClient = new PaayesClient(
                "sk_test_123",
                apiBase: "https://client.example.com");
        }

        [Fact]
        public void Ctor_GetRequest()
        {
            var request = new PaayesRequest(
                this.paayesClient,
                HttpMethod.Get,
                "/get",
                new TestOptions { String = "string!" },
                new RequestOptions());

            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal($"{this.paayesClient.ApiBase}/get?string=string!", request.Uri.ToString());
            Assert.Equal(
                $"Bearer {this.paayesClient.ApiKey}",
                request.AuthorizationHeader.ToString());
            Assert.True(request.PaayesHeaders.ContainsKey("Paayes-Version"));
            Assert.Equal(PaayesConfiguration.ApiVersion, request.PaayesHeaders["Paayes-Version"]);
            Assert.False(request.PaayesHeaders.ContainsKey("Idempotency-Key"));
            Assert.False(request.PaayesHeaders.ContainsKey("Paayes-Account"));
            Assert.Null(request.Content);
        }

        [Fact]
        public async Task Ctor_PostRequest()
        {
            var request = new PaayesRequest(
                this.paayesClient,
                HttpMethod.Post,
                "/post",
                new TestOptions { String = "string!" },
                new RequestOptions());

            Assert.Equal(HttpMethod.Post, request.Method);
            Assert.Equal($"{this.paayesClient.ApiBase}/post", request.Uri.ToString());
            Assert.Equal(
                $"Bearer {this.paayesClient.ApiKey}",
                request.AuthorizationHeader.ToString());
            Assert.True(request.PaayesHeaders.ContainsKey("Paayes-Version"));
            Assert.Equal(PaayesConfiguration.ApiVersion, request.PaayesHeaders["Paayes-Version"]);
            Assert.True(request.PaayesHeaders.ContainsKey("Idempotency-Key"));
            Assert.False(request.PaayesHeaders.ContainsKey("Paayes-Account"));
            Assert.NotNull(request.Content);
            var content = await request.Content.ReadAsStringAsync();
            Assert.Equal("string=string!", content);
        }

        [Fact]
        public void Ctor_DeleteRequest()
        {
            var request = new PaayesRequest(
                this.paayesClient,
                HttpMethod.Delete,
                "/delete",
                new TestOptions { String = "string!" },
                new RequestOptions());

            Assert.Equal(HttpMethod.Delete, request.Method);
            Assert.Equal(
                $"{this.paayesClient.ApiBase}/delete?string=string!",
                request.Uri.ToString());
            Assert.Equal(
                $"Bearer {this.paayesClient.ApiKey}",
                request.AuthorizationHeader.ToString());
            Assert.True(request.PaayesHeaders.ContainsKey("Paayes-Version"));
            Assert.Equal(PaayesConfiguration.ApiVersion, request.PaayesHeaders["Paayes-Version"]);
            Assert.False(request.PaayesHeaders.ContainsKey("Idempotency-Key"));
            Assert.False(request.PaayesHeaders.ContainsKey("Paayes-Account"));
            Assert.Null(request.Content);
        }

        [Fact]
        public void Ctor_RequestOptions()
        {
            var client = new PaayesClient("sk_test_123");
            var requestOptions = new RequestOptions
            {
                ApiKey = "sk_override",
                IdempotencyKey = "idempotency_key",
                PaayesAccount = "acct_456",
                BaseUrl = "https://override.example.com",
                PaayesVersion = "2012-12-21",
            };
            var request = new PaayesRequest(
                this.paayesClient,
                HttpMethod.Get,
                "/get",
                null,
                requestOptions);

            Assert.Equal(HttpMethod.Get, request.Method);
            Assert.Equal($"{requestOptions.BaseUrl}/get", request.Uri.ToString());
            Assert.Equal($"Bearer {requestOptions.ApiKey}", request.AuthorizationHeader.ToString());
            Assert.True(request.PaayesHeaders.ContainsKey("Paayes-Version"));
            Assert.Equal("2012-12-21", request.PaayesHeaders["Paayes-Version"]);
            Assert.True(request.PaayesHeaders.ContainsKey("Idempotency-Key"));
            Assert.Equal("idempotency_key", request.PaayesHeaders["Idempotency-Key"]);
            Assert.True(request.PaayesHeaders.ContainsKey("Paayes-Account"));
            Assert.Equal("acct_456", request.PaayesHeaders["Paayes-Account"]);
            Assert.Null(request.Content);
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyIsNull()
        {
            var client = new PaayesClient(null);
            var requestOptions = new RequestOptions();

            var exception = Assert.Throws<PaayesException>(() =>
                new PaayesRequest(client, HttpMethod.Get, "/get", null, requestOptions));

            Assert.Contains("No API key provided.", exception.Message);
        }
    }
}
