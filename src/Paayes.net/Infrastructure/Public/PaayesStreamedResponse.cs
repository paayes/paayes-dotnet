namespace Paayes
{
    using System.IO;
    using System.Net;
    using System.Net.Http.Headers;
    using System.Threading.Tasks;

    /// <summary>
    /// A streaming binary response. Body is not assumed to be text for successful responses.
    /// </summary>
    public class PaayesStreamedResponse : PaayesResponseBase
    {
        private Task<PaayesResponse> fetchFullyTask;

        public PaayesStreamedResponse(HttpStatusCode statusCode, HttpResponseHeaders headers, Stream body)
            : base(statusCode, headers)
        {
            this.Body = body;
        }

        /// <summary>
        /// Binary response body as a <see cref="Stream"/>.
        /// </summary>
        public Stream Body { get; }

        /// <summary>
        /// Converts this response into a regular <see cref="PaayesResponse"/> by
        /// reading the body in full.
        /// </summary>
        /// This assumes that the response body is textual, which will be the case for
        /// most API responses and for errors.
        /// <returns>The response with body fully read.</returns>
        public async Task<PaayesResponse> ToPaayesResponseAsync()
        {
            // We keep a reference to the task because we can only read the body once.
            if (this.fetchFullyTask == null)
            {
                this.fetchFullyTask = this.FetchResponseAsTextAsync();
            }

            return await this.fetchFullyTask.ConfigureAwait(false);
        }

        private async Task<PaayesResponse> FetchResponseAsTextAsync()
        {
            var reader = new StreamReader(this.Body);
            var content = await reader.ReadToEndAsync().ConfigureAwait(false);
            return new PaayesResponse(this.StatusCode, this.Headers, content);
        }
    }
}
