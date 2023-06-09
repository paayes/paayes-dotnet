// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SetupIntentPaymentMethodOptionsSepaDebitOptions : INestedOptions
    {
        /// <summary>
        /// Additional fields for Mandate creation.
        /// </summary>
        [JsonProperty("mandate_options")]
        public SetupIntentPaymentMethodOptionsSepaDebitMandateOptionsOptions MandateOptions { get; set; }
    }
}
