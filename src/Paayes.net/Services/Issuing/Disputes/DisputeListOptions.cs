// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using Newtonsoft.Json;

    public class DisputeListOptions : ListOptionsWithCreated
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("transaction")]
        public string Transaction { get; set; }
    }
}
