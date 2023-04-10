// File generated from our OpenAPI spec
namespace Paayes.Sigma
{
    using Newtonsoft.Json;

    public class ScheduledQueryRunError : PaayesEntity<ScheduledQueryRunError>
    {
        /// <summary>
        /// Information about the run failure.
        /// </summary>
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
