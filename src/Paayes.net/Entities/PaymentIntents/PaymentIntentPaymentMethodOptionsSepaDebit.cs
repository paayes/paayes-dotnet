// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PaymentIntentPaymentMethodOptionsSepaDebit : PaayesEntity<PaymentIntentPaymentMethodOptionsSepaDebit>
    {
        [JsonProperty("mandate_options")]
        public PaymentIntentPaymentMethodOptionsSepaDebitMandateOptions MandateOptions { get; set; }
    }
}
