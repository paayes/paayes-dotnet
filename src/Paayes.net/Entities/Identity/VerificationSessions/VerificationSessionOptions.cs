// File generated from our OpenAPI spec
namespace Paayes.Identity
{
    using Newtonsoft.Json;

    public class VerificationSessionOptions : PaayesEntity<VerificationSessionOptions>
    {
        [JsonProperty("document")]
        public VerificationSessionOptionsDocument Document { get; set; }

        [JsonProperty("id_number")]
        public VerificationSessionOptionsIdNumber IdNumber { get; set; }
    }
}
