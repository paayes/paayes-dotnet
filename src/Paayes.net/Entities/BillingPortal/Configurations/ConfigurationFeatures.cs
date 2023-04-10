// File generated from our OpenAPI spec
namespace Paayes.BillingPortal
{
    using Newtonsoft.Json;

    public class ConfigurationFeatures : PaayesEntity<ConfigurationFeatures>
    {
        [JsonProperty("customer_update")]
        public ConfigurationFeaturesCustomerUpdate CustomerUpdate { get; set; }

        [JsonProperty("invoice_history")]
        public ConfigurationFeaturesInvoiceHistory InvoiceHistory { get; set; }

        [JsonProperty("payment_method_update")]
        public ConfigurationFeaturesPaymentMethodUpdate PaymentMethodUpdate { get; set; }

        [JsonProperty("subscription_cancel")]
        public ConfigurationFeaturesSubscriptionCancel SubscriptionCancel { get; set; }

        [JsonProperty("subscription_pause")]
        public ConfigurationFeaturesSubscriptionPause SubscriptionPause { get; set; }

        [JsonProperty("subscription_update")]
        public ConfigurationFeaturesSubscriptionUpdate SubscriptionUpdate { get; set; }
    }
}
