// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class MandatePaymentMethodDetailsSepaDebit : PaayesEntity<MandatePaymentMethodDetailsSepaDebit>
    {
        /// <summary>
        /// The unique reference of the mandate.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }

        /// <summary>
        /// The URL of the mandate. This URL generally contains sensitive information about the
        /// customer and should be shared with them exclusively.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
