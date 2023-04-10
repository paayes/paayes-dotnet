// File generated from our OpenAPI spec
namespace Paayes.Checkout
{
    using Newtonsoft.Json;

    public class SessionPaymentMethodOptionsAcssDebit : PaayesEntity<SessionPaymentMethodOptionsAcssDebit>
    {
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("mandate_options")]
        public SessionPaymentMethodOptionsAcssDebitMandateOptions MandateOptions { get; set; }

        /// <summary>
        /// Bank account verification method.
        /// One of: <c>automatic</c>, <c>instant</c>, or <c>microdeposits</c>.
        /// </summary>
        [JsonProperty("verification_method")]
        public string VerificationMethod { get; set; }
    }
}
