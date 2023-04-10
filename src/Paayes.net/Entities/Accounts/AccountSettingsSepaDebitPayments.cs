// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountSettingsSepaDebitPayments : PaayesEntity<AccountSettingsSepaDebitPayments>
    {
        /// <summary>
        /// SEPA creditor identifier that identifies the company making the payment.
        /// </summary>
        [JsonProperty("creditor_id")]
        public string CreditorId { get; set; }
    }
}
