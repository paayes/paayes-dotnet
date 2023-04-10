// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PaymentMethodBoleto : PaayesEntity<PaymentMethodBoleto>
    {
        /// <summary>
        /// Uniquely identifies the customer tax id (CNPJ or CPF).
        /// </summary>
        [JsonProperty("tax_id")]
        public string TaxId { get; set; }
    }
}
