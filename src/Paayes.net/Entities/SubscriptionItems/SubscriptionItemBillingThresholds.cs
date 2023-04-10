// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SubscriptionItemBillingThresholds : PaayesEntity<SubscriptionItemBillingThresholds>
    {
        /// <summary>
        /// Usage threshold that triggers the subscription to create an invoice.
        /// </summary>
        [JsonProperty("usage_gte")]
        public long? UsageGte { get; set; }
    }
}
