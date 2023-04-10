// File generated from our OpenAPI spec
namespace Paayes.Checkout
{
    using Newtonsoft.Json;

    public class SessionPaymentMethodOptions : PaayesEntity<SessionPaymentMethodOptions>
    {
        [JsonProperty("acss_debit")]
        public SessionPaymentMethodOptionsAcssDebit AcssDebit { get; set; }

        [JsonProperty("boleto")]
        public SessionPaymentMethodOptionsBoleto Boleto { get; set; }

        [JsonProperty("oxxo")]
        public SessionPaymentMethodOptionsOxxo Oxxo { get; set; }
    }
}
