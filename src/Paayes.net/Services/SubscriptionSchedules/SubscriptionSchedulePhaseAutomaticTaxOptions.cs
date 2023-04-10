// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SubscriptionSchedulePhaseAutomaticTaxOptions : INestedOptions
    {
        /// <summary>
        /// Enabled automatic tax calculation which will automatically compute tax rates on all
        /// invoices generated by the subscription.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
    }
}