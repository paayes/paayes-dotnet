namespace Paayes
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Interface for HTTP clients used to make requests to Paayes's API.
    /// </summary>
    public interface IHttpClient
    {
        /// <summary>Sends a request to Paayes's API as an asynchronous operation.</summary>
        /// <param name="request">The parameters of the request to send.</param>
        /// <param name="cancellationToken">The cancellation token to cancel operation.</param>
        /// <returns>The task object representing the asynchronous operation.</returns>
        Task<PaayesResponse> MakeRequestAsync(
            PaayesRequest request,
            CancellationToken cancellationToken = default);

        Task<PaayesStreamedResponse> MakeStreamingRequestAsync(
            PaayesRequest request,
            CancellationToken cancellationToken = default);
    }
}
