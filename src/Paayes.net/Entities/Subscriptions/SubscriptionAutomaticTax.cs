// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SubscriptionAutomaticTax : PaayesEntity<SubscriptionAutomaticTax>
    {
        /// <summary>
        /// Whether Paayes automatically computes tax on this subscription.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
