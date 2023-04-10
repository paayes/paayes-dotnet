// File generated from our OpenAPI spec
namespace Paayes.BillingPortal
{
    using Newtonsoft.Json;

    public class ConfigurationFeaturesSubscriptionPause : PaayesEntity<ConfigurationFeaturesSubscriptionPause>
    {
        /// <summary>
        /// Whether the feature is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
