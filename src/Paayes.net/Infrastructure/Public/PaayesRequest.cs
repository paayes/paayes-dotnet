namespace Paayes
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using System.Text;
    using Paayes.Infrastructure;
    using Paayes.Infrastructure.FormEncoding;

    /// <summary>
    /// Represents a request to Paayes's API.
    /// </summary>
    public class PaayesRequest
    {
        private readonly BaseOptions options;

        /// <summary>Initializes a new instance of the <see cref="PaayesRequest"/> class.</summary>
        /// <param name="client">The client creating the request.</param>
        /// <param name="method">The HTTP method.</param>
        /// <param name="path">The path of the request.</param>
        /// <param name="options">The parameters of the request.</param>
        /// <param name="requestOptions">The special modifiers of the request.</param>
        public PaayesRequest(
            IPaayesClient client,
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            if (client == null)
            {
                throw new ArgumentNullException(nameof(client));
            }

            this.options = options;

            this.Method = method;

            this.Uri = BuildUri(client, method, path, options, requestOptions);

            this.AuthorizationHeader = BuildAuthorizationHeader(client, requestOptions);

            this.PaayesHeaders = BuildPaayesHeaders(method, requestOptions);
        }

        /// <summary>The HTTP method for the request (GET, POST or DELETE).</summary>
        public HttpMethod Method { get; }

        /// <summary>
        /// The URL for the request. If this is a GET or DELETE request, the URL also includes
        /// the request parameters in its query string.
        /// </summary>
        public Uri Uri { get; }

        /// <summary>The value of the <c>Authorization</c> header with the API key.</summary>
        public AuthenticationHeaderValue AuthorizationHeader { get; }

        /// <summary>
        /// Dictionary containing Paayes custom headers (<c>Paayes-Version</c>,
        /// <c>Paayes-Account</c>, <c>Idempotency-Key</c>...).
        /// </summary>
        public IDictionary<string, string> PaayesHeaders { get; }

        /// <summary>
        /// The body of the request. For POST requests, this will be either a
        /// <c>application/x-www-form-urlencoded</c> or a <c>multipart/form-data</c> payload.
        /// For non-POST requests, this will be <c>null</c>.
        /// </summary>
        /// <remarks>This getter creates a new instance every time it is called.</remarks>
        public HttpContent Content => BuildContent(this.Method, this.options);

        /// <summary>Returns a string that represents the <see cref="PaayesRequest"/>.</summary>
        /// <returns>A string that represents the <see cref="PaayesRequest"/>.</returns>
        public override string ToString()
        {
            return string.Format(
                "<{0} Method={1} Uri={2}>",
                this.GetType().FullName,
                this.Method,
                this.Uri.ToString());
        }

        private static Uri BuildUri(
            IPaayesClient client,
            HttpMethod method,
            string path,
            BaseOptions options,
            RequestOptions requestOptions)
        {
            var b = new StringBuilder();

            b.Append(requestOptions?.BaseUrl ?? client.ApiBase);
            b.Append(path);

            if ((method != HttpMethod.Post) && (options != null))
            {
                var queryString = FormEncoder.CreateQueryString(options);
                if (!string.IsNullOrEmpty(queryString))
                {
                    b.Append("?");
                    b.Append(queryString);
                }
            }

            return new Uri(b.ToString());
        }

        private static AuthenticationHeaderValue BuildAuthorizationHeader(
            IPaayesClient client,
            RequestOptions requestOptions)
        {
            string apiKey = requestOptions?.ApiKey ?? client.ApiKey;

            if (apiKey == null)
            {
                var message = "No API key provided. Set your API key using "
                    + "`PaayesConfiguration.ApiKey = \"<API-KEY>\"`. You can generate API keys "
                    + "from the Paayes Dashboard. See "
                    + "https://docs.paayes.com/api/authentication for details or contact support "
                    + "at https://support.paayes.com/email if you have any questions.";
                throw new PaayesException(message);
            }

            return new AuthenticationHeaderValue("Bearer", apiKey);
        }

        private static Dictionary<string, string> BuildPaayesHeaders(
            HttpMethod method,
            RequestOptions requestOptions)
        {
            var paayesHeaders = new Dictionary<string, string>
            {
                { "Paayes-Version", requestOptions?.PaayesVersion ?? PaayesConfiguration.ApiVersion },
            };

            if (!string.IsNullOrEmpty(requestOptions?.PaayesAccount))
            {
                paayesHeaders.Add("Paayes-Account", requestOptions.PaayesAccount);
            }

            if (!string.IsNullOrEmpty(requestOptions?.IdempotencyKey))
            {
                paayesHeaders.Add("Idempotency-Key", requestOptions.IdempotencyKey);
            }
            else if (method == HttpMethod.Post)
            {
                paayesHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
            }

            return paayesHeaders;
        }

        private static HttpContent BuildContent(HttpMethod method, BaseOptions options)
        {
            if (method != HttpMethod.Post)
            {
                return null;
            }

            return FormEncoder.CreateHttpContent(options);
        }
    }
}
