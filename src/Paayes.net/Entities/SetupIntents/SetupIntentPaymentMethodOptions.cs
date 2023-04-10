// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SetupIntentPaymentMethodOptions : PaayesEntity<SetupIntentPaymentMethodOptions>
    {
        [JsonProperty("acss_debit")]
        public SetupIntentPaymentMethodOptionsAcssDebit AcssDebit { get; set; }

        [JsonProperty("card")]
        public SetupIntentPaymentMethodOptionsCard Card { get; set; }

        [JsonProperty("sepa_debit")]
        public SetupIntentPaymentMethodOptionsSepaDebit SepaDebit { get; set; }
    }
}
