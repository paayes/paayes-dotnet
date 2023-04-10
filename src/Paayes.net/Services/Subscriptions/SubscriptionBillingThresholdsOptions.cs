// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SubscriptionBillingThresholdsOptions : INestedOptions
    {
        /// <summary>
        /// Monetary threshold that triggers the subscription to advance to a new billing period.
        /// </summary>
        [JsonProperty("amount_gte")]
        public long? AmountGte { get; set; }

        /// <summary>
        /// Indicates if the <c>billing_cycle_anchor</c> should be reset when a threshold is
        /// reached. If true, <c>billing_cycle_anchor</c> will be updated to the date/time the
        /// threshold was last reached; otherwise, the value will remain unchanged.
        /// </summary>
        [JsonProperty("reset_billing_cycle_anchor")]
        public bool? ResetBillingCycleAnchor { get; set; }
    }
}