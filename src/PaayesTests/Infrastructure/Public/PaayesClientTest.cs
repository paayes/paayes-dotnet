namespace PaayesTests
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Paayes;
    using Xunit;

    public class PaayesClientTest : BasePaayesTest
    {
        private readonly DummyHttpClient httpClient;
        private readonly PaayesClient paayesClient;
        private readonly BaseOptions options;
        private readonly RequestOptions requestOptions;

        public PaayesClientTest()
        {
            this.httpClient = new DummyHttpClient();
            this.paayesClient = new PaayesClient(
                "sk_test_123",
                httpClient: this.httpClient);
            this.options = new ChargeCreateOptions
            {
                Amount = 123,
                Currency = "usd",
                Source = "tok_visa",
            };
            this.requestOptions = new RequestOptions();
        }

        [Fact]
        public void Ctor_DoesNotThrowsIfApiKeyIsNull()
        {
            var client = new PaayesClient(null);
            Assert.NotNull(client);
            Assert.Null(client.ApiKey);
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyIsEmpty()
        {
            var exception = Assert.Throws<ArgumentException>(() => new PaayesClient(string.Empty));
            Assert.Contains("API key cannot be the empty string.", exception.Message);
        }

        [Fact]
        public void Ctor_ThrowsIfApiKeyContainsWhitespace()
        {
            var exception = Assert.Throws<ArgumentException>(() => new PaayesClient("sk_test_123\n"));
            Assert.Contains("API key cannot contain whitespace.", exception.Message);
        }

        [Fact]
        public async Task RequestAsync_OkResponse()
        {
            var response = new PaayesResponse(HttpStatusCode.OK, null, "{\"id\": \"ch_123\"}");
            this.httpClient.Response = response;

            var charge = await this.paayesClient.RequestAsync<Charge>(
                HttpMethod.Post,
                "/v1/charges",
                this.options,
                this.requestOptions);

            Assert.NotNull(charge);
            Assert.Equal("ch_123", charge.Id);
            Assert.Equal(response, charge.PaayesResponse);
        }

        [Fact]
        public async Task RequestAsync_OkResponse_InvalidJson()
        {
            var response = new PaayesResponse(HttpStatusCode.OK, null, "this isn't JSON");
            this.httpClient.Response = response;

            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
                await this.paayesClient.RequestAsync<Charge>(
                    HttpMethod.Post,
                    "/v1/charges",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.OK, exception.HttpStatusCode);
            Assert.Equal("Invalid response object from API: \"this isn't JSON\"", exception.Message);
            Assert.Equal(response, exception.PaayesResponse);
        }

        [Fact]
        public async Task RequestAsync_ApiError()
        {
            var response = new PaayesResponse(
                HttpStatusCode.PaymentRequired,
                null,
                "{\"error\": {\"type\": \"card_error\"}}");
            this.httpClient.Response = response;

            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
                await this.paayesClient.RequestAsync<Charge>(
                    HttpMethod.Post,
                    "/v1/charges",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.PaymentRequired, exception.HttpStatusCode);
            Assert.Equal("card_error", exception.PaayesError.Type);
            Assert.Equal(response, exception.PaayesResponse);
        }

        [Fact]
        public async Task RequestAsync_OAuthError()
        {
            var response = new PaayesResponse(
                HttpStatusCode.BadRequest,
                null,
                "{\"error\": \"invalid_request\"}");
            this.httpClient.Response = response;

            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
                await this.paayesClient.RequestAsync<OAuthToken>(
                    HttpMethod.Post,
                    "/oauth/token",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.BadRequest, exception.HttpStatusCode);
            Assert.Equal("invalid_request", exception.PaayesError.Error);
            Assert.Equal(response, exception.PaayesResponse);
        }

        [Fact]
        public async Task RequestAsync_Error_InvalidJson()
        {
            var response = new PaayesResponse(
                HttpStatusCode.InternalServerError,
                null,
                "this isn't JSON");
            this.httpClient.Response = response;

            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
                await this.paayesClient.RequestAsync<Charge>(
                    HttpMethod.Post,
                    "/v1/charges",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.InternalServerError, exception.HttpStatusCode);
            Assert.Equal("Invalid response object from API: \"this isn't JSON\"", exception.Message);
            Assert.Equal(response, exception.PaayesResponse);
        }

        [Fact]
        public async Task RequestAsync_Error_InvalidErrorObject()
        {
            var response = new PaayesResponse(
                HttpStatusCode.InternalServerError,
                null,
                "{}");
            this.httpClient.Response = response;

            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
                await this.paayesClient.RequestAsync<Charge>(
                    HttpMethod.Post,
                    "/v1/charges",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.InternalServerError, exception.HttpStatusCode);
            Assert.Equal("Invalid response object from API: \"{}\"", exception.Message);
            Assert.Equal(response, exception.PaayesResponse);
        }

        [Fact]
        public async Task RequestStreamingAsync_OkResponse_InvalidJson()
        {
            var streamedResponse = new PaayesStreamedResponse(
                HttpStatusCode.OK,
                null,
                StringToStream("this isn't JSON"));
            this.httpClient.StreamedResponse = streamedResponse;

            var stream = await this.paayesClient.RequestStreamingAsync(
                HttpMethod.Post,
                "/v1/charges",
                this.options,
                this.requestOptions);

            Assert.NotNull(stream);
            Assert.Equal("this isn't JSON", StreamToString(stream));
        }

        [Fact]
        public async Task RequestStreamingAsync_ApiError()
        {
            var streamedResponse = new PaayesStreamedResponse(
                HttpStatusCode.PaymentRequired,
                null,
                StringToStream("{\"error\": {\"type\": \"card_error\"}}"));
            this.httpClient.StreamedResponse = streamedResponse;

            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
                await this.paayesClient.RequestStreamingAsync(
                    HttpMethod.Post,
                    "/v1/charges",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.PaymentRequired, exception.HttpStatusCode);
            Assert.Equal("card_error", exception.PaayesError.Type);
            Assert.Equal(await streamedResponse.ToPaayesResponseAsync(), exception.PaayesResponse);
        }

        [Fact]
        public async Task RequestStreamingAsync_OAuthError()
        {
            var streamedResponse = new PaayesStreamedResponse(
                HttpStatusCode.BadRequest,
                null,
                StringToStream("{\"error\": \"invalid_request\"}"));
            this.httpClient.StreamedResponse = streamedResponse;

            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
                await this.paayesClient.RequestStreamingAsync(
                    HttpMethod.Post,
                    "/oauth/token",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.BadRequest, exception.HttpStatusCode);
            Assert.Equal("invalid_request", exception.PaayesError.Error);
            Assert.Equal(await streamedResponse.ToPaayesResponseAsync(), exception.PaayesResponse);
        }

        [Fact]
        public async Task RequestStreamingAsync_Error_InvalidErrorObject()
        {
            var streamedResponse = new PaayesStreamedResponse(
                HttpStatusCode.InternalServerError,
                null,
                StringToStream("{}"));
            this.httpClient.StreamedResponse = streamedResponse;

            var exception = await Assert.ThrowsAsync<PaayesException>(async () =>
                await this.paayesClient.RequestStreamingAsync(
                    HttpMethod.Post,
                    "/v1/charges",
                    this.options,
                    this.requestOptions));

            Assert.NotNull(exception);
            Assert.Equal(HttpStatusCode.InternalServerError, exception.HttpStatusCode);
            Assert.Equal("Invalid response object from API: \"{}\"", exception.Message);
            Assert.Equal(await streamedResponse.ToPaayesResponseAsync(), exception.PaayesResponse);
        }

        private static Stream StringToStream(string content)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(content));
        }

        private static string StreamToString(Stream stream)
        {
            return new StreamReader(stream, Encoding.UTF8).ReadToEnd();
        }

        private class DummyHttpClient : IHttpClient
        {
            public PaayesResponse Response { get; set; }

            public PaayesStreamedResponse StreamedResponse { get; set; }

            public Task<PaayesResponse> MakeRequestAsync(
                PaayesRequest request,
                CancellationToken cancellationToken = default)
            {
                if (this.Response == null)
                {
                    throw new PaayesTestException("Response is null");
                }

                return Task.FromResult<PaayesResponse>(this.Response);
            }

            public Task<PaayesStreamedResponse> MakeStreamingRequestAsync(
                PaayesRequest request,
                CancellationToken cancellationToken = default)
            {
                if (this.StreamedResponse == null)
                {
                    throw new PaayesTestException("StreamedResponse is null");
                }

                return Task.FromResult(this.StreamedResponse);
            }
        }
    }
}
