// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class TopupListOptions : ListOptionsWithCreated
    {
        [JsonProperty("status")]
        public string Status { get; set; }
    }
}
