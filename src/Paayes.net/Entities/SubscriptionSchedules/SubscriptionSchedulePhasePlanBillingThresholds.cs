namespace Paayes
{
    using Newtonsoft.Json;

    public class SubscriptionSchedulePhasePlanBillingThresholds : PaayesEntity<SubscriptionSchedulePhasePlanBillingThresholds>
    {
        [JsonProperty("usage_gte")]
        public long? UsageGte { get; set; }
    }
}
