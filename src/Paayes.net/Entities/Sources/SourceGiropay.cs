// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SourceGiropay : PaayesEntity<SourceGiropay>
    {
        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }
    }
}
