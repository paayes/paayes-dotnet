// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class ChargePaymentMethodDetailsMultibanco : PaayesEntity<ChargePaymentMethodDetailsMultibanco>
    {
        /// <summary>
        /// Entity number associated with this Multibanco payment.
        /// </summary>
        [JsonProperty("entity")]
        public string Entity { get; set; }

        /// <summary>
        /// Reference number associated with this Multibanco payment.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
