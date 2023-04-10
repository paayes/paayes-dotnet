// File generated from our OpenAPI spec
namespace Paayes.BillingPortal
{
    using Newtonsoft.Json;

    public class ConfigurationListOptions : ListOptions
    {
        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("is_default")]
        public bool? IsDefault { get; set; }
    }
}
