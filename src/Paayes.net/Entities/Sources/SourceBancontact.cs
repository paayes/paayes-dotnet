// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SourceBancontact : PaayesEntity<SourceBancontact>
    {
        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("iban_last4")]
        public string IbanLast4 { get; set; }

        [JsonProperty("preferred_language")]
        public string PreferredLanguage { get; set; }
    }
}
