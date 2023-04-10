// File generated from our OpenAPI spec
namespace Paayes.Radar
{
    using Newtonsoft.Json;

    public class EarlyFraudWarningListOptions : ListOptions
    {
        [JsonProperty("charge")]
        public string Charge { get; set; }

        [JsonProperty("payment_intent")]
        public string PaymentIntent { get; set; }
    }
}
