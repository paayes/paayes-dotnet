// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SubscriptionSchedulePhaseAutomaticTax : PaayesEntity<SubscriptionSchedulePhaseAutomaticTax>
    {
        /// <summary>
        /// Whether Paayes automatically computes tax on invoices created during this phase.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
