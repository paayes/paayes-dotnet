// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SubscriptionPaymentSettingsPaymentMethodOptions : PaayesEntity<SubscriptionPaymentSettingsPaymentMethodOptions>
    {
        /// <summary>
        /// This sub-hash contains details about the Bancontact payment method options to pass to
        /// invoices created by the subscription.
        /// </summary>
        [JsonProperty("bancontact")]
        public SubscriptionPaymentSettingsPaymentMethodOptionsBancontact Bancontact { get; set; }

        /// <summary>
        /// This sub-hash contains details about the Card payment method options to pass to invoices
        /// created by the subscription.
        /// </summary>
        [JsonProperty("card")]
        public SubscriptionPaymentSettingsPaymentMethodOptionsCard Card { get; set; }
    }
}
