namespace Paayes
{
    using Newtonsoft.Json;

    public class ChargePaymentMethodDetailsSofort : PaayesEntity<ChargePaymentMethodDetailsSofort>
    {
        [JsonProperty("bank_code")]
        public string BankCode { get; set; }

        [JsonProperty("bank_name")]
        public string BankName { get; set; }

        [JsonProperty("bic")]
        public string Bic { get; set; }

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("iban_last4")]
        public string IbanLast4 { get; set; }

        [JsonProperty("verified_name")]
        public string VerifiedName { get; set; }
    }
}
