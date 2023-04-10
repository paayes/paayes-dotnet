// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PaymentIntentPaymentMethodOptionsAcssDebit : PaayesEntity<PaymentIntentPaymentMethodOptionsAcssDebit>
    {
        [JsonProperty("mandate_options")]
        public PaymentIntentPaymentMethodOptionsAcssDebitMandateOptions MandateOptions { get; set; }

        /// <summary>
        /// Bank account verification method.
        /// One of: <c>automatic</c>, <c>instant</c>, or <c>microdeposits</c>.
        /// </summary>
        [JsonProperty("verification_method")]
        public string VerificationMethod { get; set; }
    }
}
