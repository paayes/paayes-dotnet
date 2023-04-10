// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class ChargePaymentMethodDetailsAfterpayClearpay : PaayesEntity<ChargePaymentMethodDetailsAfterpayClearpay>
    {
        /// <summary>
        /// Order identifier shown to the merchant in Afterpay’s online portal.
        /// </summary>
        [JsonProperty("reference")]
        public string Reference { get; set; }
    }
}
