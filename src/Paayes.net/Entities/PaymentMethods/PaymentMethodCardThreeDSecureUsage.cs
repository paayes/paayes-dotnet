// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PaymentMethodCardThreeDSecureUsage : PaayesEntity<PaymentMethodCardThreeDSecureUsage>
    {
        /// <summary>
        /// Whether 3D Secure is supported on this card.
        /// </summary>
        [JsonProperty("supported")]
        public bool Supported { get; set; }
    }
}
