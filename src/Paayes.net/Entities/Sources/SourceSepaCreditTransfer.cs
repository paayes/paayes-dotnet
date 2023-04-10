// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SourceSepaCreditTransfer : PaayesEntity<SourceSepaCreditTransfer>
    {
        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("iban")]
        public string Iban { get; set; }
    }
}
