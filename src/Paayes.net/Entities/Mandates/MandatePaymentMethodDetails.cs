// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class MandatePaymentMethodDetails : PaayesEntity<MandatePaymentMethodDetails>
    {
        [JsonProperty("acss_debit")]
        public MandatePaymentMethodDetailsAcssDebit AcssDebit { get; set; }

        [JsonProperty("au_becs_debit")]
        public MandatePaymentMethodDetailsAuBecsDebit AuBecsDebit { get; set; }

        [JsonProperty("bacs_debit")]
        public MandatePaymentMethodDetailsBacsDebit BacsDebit { get; set; }

        [JsonProperty("card")]
        public MandatePaymentMethodDetailsCard Card { get; set; }

        [JsonProperty("sepa_debit")]
        public MandatePaymentMethodDetailsSepaDebit SepaDebit { get; set; }

        /// <summary>
        /// The type of the payment method associated with this mandate. An additional hash is
        /// included on <c>payment_method_details</c> with a name matching this value. It contains
        /// mandate information specific to the payment method.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
