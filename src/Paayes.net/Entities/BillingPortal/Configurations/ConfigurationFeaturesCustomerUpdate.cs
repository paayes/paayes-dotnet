// File generated from our OpenAPI spec
namespace Paayes.BillingPortal
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class ConfigurationFeaturesCustomerUpdate : PaayesEntity<ConfigurationFeaturesCustomerUpdate>
    {
        /// <summary>
        /// The types of customer updates that are supported. When empty, customers are not
        /// updateable.
        /// </summary>
        [JsonProperty("allowed_updates")]
        public List<string> AllowedUpdates { get; set; }

        /// <summary>
        /// Whether the feature is enabled.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
