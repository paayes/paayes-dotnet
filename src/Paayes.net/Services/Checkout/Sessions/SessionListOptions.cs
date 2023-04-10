// File generated from our OpenAPI spec
namespace Paayes.Checkout
{
    using Newtonsoft.Json;

    public class SessionListOptions : ListOptions
    {
        [JsonProperty("payment_intent")]
        public string PaymentIntent { get; set; }

        [JsonProperty("subscription")]
        public string Subscription { get; set; }
    }
}
