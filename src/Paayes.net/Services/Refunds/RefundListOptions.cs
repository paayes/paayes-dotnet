// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class RefundListOptions : ListOptionsWithCreated
    {
        [JsonProperty("charge")]
        public string Charge { get; set; }

        [JsonProperty("payment_intent")]
        public string PaymentIntent { get; set; }
    }
}
