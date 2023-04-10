// File generated from our OpenAPI spec
namespace Paayes.Identity
{
    using Newtonsoft.Json;

    public class VerificationReportOptions : PaayesEntity<VerificationReportOptions>
    {
        [JsonProperty("document")]
        public VerificationReportOptionsDocument Document { get; set; }

        [JsonProperty("id_number")]
        public VerificationReportOptionsIdNumber IdNumber { get; set; }
    }
}
