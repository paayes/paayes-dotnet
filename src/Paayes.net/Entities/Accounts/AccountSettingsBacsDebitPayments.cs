// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountSettingsBacsDebitPayments : PaayesEntity<AccountSettingsBacsDebitPayments>
    {
        /// <summary>
        /// The Bacs Direct Debit Display Name for this account. For payments made with Bacs Direct
        /// Debit, this will appear on the mandate, and as the statement descriptor.
        /// </summary>
        [JsonProperty("display_name")]
        public string DisplayName { get; set; }
    }
}
