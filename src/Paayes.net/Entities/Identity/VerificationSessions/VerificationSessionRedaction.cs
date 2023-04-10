// File generated from our OpenAPI spec
namespace Paayes.Identity
{
    using Newtonsoft.Json;

    public class VerificationSessionRedaction : PaayesEntity<VerificationSessionRedaction>
    {
        /// <summary>
        /// Indicates whether this object and its related objects have been redacted or not.
        /// One of: <c>processing</c>, or <c>redacted</c>.
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
