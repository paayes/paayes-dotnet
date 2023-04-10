namespace Paayes
{
    using System;
    using System.IO;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;
    using Newtonsoft.Json.Linq;
    using Paayes.Infrastructure;

    /// <summary>
    /// A Paayes client, used to issue requests to Paayes's API and deserialize responses.
    /// </summary>
    public class PaayesClient : IPaayesClient
    {
        /// <summary>Initializes a new instance of the <see cref="PaayesClient"/> class.</summary>
        /// <param name="apiKey">The API key used by the client to make requests.</param>
        /// <param name="clientId">The client ID used by the client in OAuth requests.</param>
        /// <param name="httpClient">
        /// The <see cref="IHttpClient"/> client to use. If <c>null</c>, an HTTP client will be
        /// created with default parameters.
        /// </param>
        /// <param name="apiBase">
        /// The base URL for Paayes's API. Defaults to <see cref="DefaultApiBase"/>.
        /// </param>
        /// <param name="connectBase">
        /// The base URL for Paayes's OAuth API. Defaults to <see cref="DefaultConnectBase"/>.
        /// </param>
        /// <param name="filesBase">
        /// The base URL for Paayes's Files API. Defaults to <see cref="DefaultFilesBase"/>.
        /// </param>
        /// <exception cref="ArgumentNullException">if <c>apiKey</c> is <c>null</c>.</exception>
        /// <exception cref="ArgumentException">
        /// if <c>apiKey</c> is empty or contains whitespace.
        /// </exception>
        public PaayesClient(
            string apiKey = null,
            string clientId = null,
            IHttpClient httpClient = null,
            string apiBase = null,
            string connectBase = null,
            string filesBase = null)
        {
            if (apiKey != null && apiKey.Length == 0)
            {
                throw new ArgumentException("API key cannot be the empty string.", nameof(apiKey));
            }

            if (apiKey != null && StringUtils.ContainsWhitespace(apiKey))
            {
                throw new ArgumentException("API key cannot contain whitespace.", nameof(apiKey));
            }

            this.ApiKey = apiKey;
            this.ClientId = clientId;
            this.HttpClient = httpClient ?? BuildDefaultHttpClient();
            this.ApiBase = apiBase ?? DefaultApiBase;
            this.ConnectBase = connectBase ?? DefaultConnectBase;
            this.FilesBase = filesBase ?? DefaultFilesBase;
        }

        /// <summary>Default base URL for Paayes's API.</summary>
        public static string DefaultApiBase => "https://api.paayes.com";

        /// <summary>Default base URL for Paayes's OAuth API.</summary>
        public static string DefaultConnectBase => "";

        /// <summary>Default base URL for Paayes's Files API.</summary>
        public static string DefaultFilesBase => "";

        /// <summary>Gets the base URL for Paayes's API.</summary>
        /// <value>The base URL for Paayes's API.</value>
        public string ApiBase { get; }

        /// <summary>Gets the API key used by the client to send requests.</summary>
        /// <value>The API key used by the client to send requests.</value>
        public string ApiKey { get; }

        /// <summary>Gets the client ID used by the client in OAuth requests.</summary>
        /// <value>The client ID used by the client in OAuth requests.</value>
        public string ClientId { get; }

        /// <summary>Gets the base URL for Paayes's OAuth API.</summary>
        /// <value>The base URL for Paayes's OAuth API.</value>
        public string ConnectBase { get; }

        /// <summary>Gets the base URL for Paayes's Files API.</summary>
        /// <value>The base URL for Paayes's Files API.</value>
        public string FilesBase { get; }

        /// <summary>Gets the <see cref="IHttpClient"/> used to send HTTP requests.</summary>
        /// <value>The <see cref="IHttpClient"/> used to send HTTP requests.</value>
        public IHttpClient HttpClient { get; }

        /// <summary>Sends a request to Paayes's API as an asynchronous operation.</summary>
        /// <typeparam name="T">Type of the Paayes entity returned by the API.</typeparam>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        /// <exception cref="PaayesException">Thrown if the request fails.</exception>
        public async Task<T> RequestAsync<T>(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
            where T : IPaayesEntity
        {
            var request = new PaayesRequest(this, method, path, options, requestOptions);

            var response = await this.HttpClient.MakeRequestAsync(request, cancellationToken)
                .ConfigureAwait(false);

            return ProcessResponse<T>(response);
        }

        /// <inheritdoc/>
        public async Task<Stream> RequestStreamingAsync(
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions,
            CancellationToken cancellationToken = default)
        {
            var request = new PaayesRequest(this, method, path, options, requestOptions);

            var response = await this.HttpClient.MakeStreamingRequestAsync(request, cancellationToken)
                .ConfigureAwait(false);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return response.Body;
            }

            var readResponse = await response.ToPaayesResponseAsync().ConfigureAwait(false);
            throw BuildPaayesException(readResponse);
        }

        private static IHttpClient BuildDefaultHttpClient()
        {
            return new SystemNetHttpClient();
        }

        private static T ProcessResponse<T>(PaayesResponse response)
            where T : IPaayesEntity
        {
            if (response.StatusCode != HttpStatusCode.OK)
            {
                throw BuildPaayesException(response);
            }

            T obj;
            try
            {
                obj = PaayesEntity.FromJson<T>(response.Content);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                throw BuildInvalidResponseException(response);
            }

            obj.PaayesResponse = response;

            return obj;
        }

        private static PaayesException BuildPaayesException(PaayesResponse response)
        {
            JObject jObject = null;

            try
            {
                jObject = JObject.Parse(response.Content);
            }
            catch (Newtonsoft.Json.JsonException)
            {
                return BuildInvalidResponseException(response);
            }

            // If the value of the `error` key is a string, then the error is an OAuth error
            // and we instantiate the PaayesError object with the entire JSON.
            // Otherwise, it's a regular API error and we instantiate the PaayesError object
            // with just the nested hash contained in the `error` key.
            var errorToken = jObject["error"];
            if (errorToken == null)
            {
                return BuildInvalidResponseException(response);
            }

            var paayesError = errorToken.Type == JTokenType.String
                ? PaayesError.FromJson(response.Content)
                : PaayesError.FromJson(errorToken.ToString());

            paayesError.PaayesResponse = response;

            return new PaayesException(
                response.StatusCode,
                paayesError,
                paayesError.Message ?? paayesError.ErrorDescription)
            {
                PaayesResponse = response,
            };
        }

        private static PaayesException BuildInvalidResponseException(PaayesResponse response)
        {
            return new PaayesException(
                response.StatusCode,
                null,
                $"Invalid response object from API: \"{response.Content}\"")
            {
                PaayesResponse = response,
            };
        }
    }
}
