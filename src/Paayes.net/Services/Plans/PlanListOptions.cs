// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PlanListOptions : ListOptionsWithCreated
    {
        [JsonProperty("active")]
        public bool? Active { get; set; }

        [JsonProperty("product")]
        public string Product { get; set; }
    }
}
