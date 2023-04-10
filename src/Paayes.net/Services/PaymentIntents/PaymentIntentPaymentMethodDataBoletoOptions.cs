// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PaymentIntentPaymentMethodDataBoletoOptions : INestedOptions
    {
        /// <summary>
        /// Uniquely identifies this customer tax_id (CNPJ or CPF).
        /// </summary>
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
    }
}
