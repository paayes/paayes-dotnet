// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class ChargePaymentMethodDetailsOxxo : PaayesEntity<ChargePaymentMethodDetailsOxxo>
    {
        /// <summary>
        /// OXXO reference number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
