// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PaymentMethodListOptions : ListOptions
    {
        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
