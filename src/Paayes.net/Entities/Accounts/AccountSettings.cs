// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountSettings : PaayesEntity<AccountSettings>
    {
        [JsonProperty("bacs_debit_payments")]
        public AccountSettingsBacsDebitPayments BacsDebitPayments { get; set; }

        [JsonProperty("branding")]
        public AccountSettingsBranding Branding { get; set; }

        [JsonProperty("card_issuing")]
        public AccountSettingsCardIssuing CardIssuing { get; set; }

        [JsonProperty("card_payments")]
        public AccountSettingsCardPayments CardPayments { get; set; }

        [JsonProperty("dashboard")]
        public AccountSettingsDashboard Dashboard { get; set; }

        [JsonProperty("payments")]
        public AccountSettingsPayments Payments { get; set; }

        [JsonProperty("payouts")]
        public AccountSettingsPayouts Payouts { get; set; }

        [JsonProperty("sepa_debit_payments")]
        public AccountSettingsSepaDebitPayments SepaDebitPayments { get; set; }
    }
}
