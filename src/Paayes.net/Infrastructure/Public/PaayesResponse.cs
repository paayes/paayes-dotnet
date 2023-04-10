namespace Paayes
{
    using System.Net;
    using System.Net.Http.Headers;

    /// <summary>
    /// Represents a buffered textual response from Paayes's API.
    /// </summary>
    public class PaayesResponse : PaayesResponseBase
    {
        /// <summary>Initializes a new instance of the <see cref="PaayesResponse"/> class.</summary>
        /// <param name="statusCode">The HTTP status code.</param>
        /// <param name="headers">The HTTP headers of the response.</param>
        /// <param name="content">The body of the response.</param>
        public PaayesResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, string content)
            : base(statusCode, headers)
        {
            this.Content = content;
        }

        /// <summary>Gets the body of the response.</summary>
        /// <value>The body of the response.</value>
        public string Content { get; }
    }
}
