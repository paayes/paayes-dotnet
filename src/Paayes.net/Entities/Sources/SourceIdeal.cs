// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SourceIdeal : PaayesEntity<SourceIdeal>
    {
        [JsonProperty("bank")]
        public string Bank { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("iban_last4")]
        public string IbanLast4 { get; set; }
    }
}
