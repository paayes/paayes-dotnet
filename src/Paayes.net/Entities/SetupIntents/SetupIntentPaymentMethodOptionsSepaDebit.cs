// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SetupIntentPaymentMethodOptionsSepaDebit : PaayesEntity<SetupIntentPaymentMethodOptionsSepaDebit>
    {
        [JsonProperty("mandate_options")]
        public SetupIntentPaymentMethodOptionsSepaDebitMandateOptions MandateOptions { get; set; }
    }
}
