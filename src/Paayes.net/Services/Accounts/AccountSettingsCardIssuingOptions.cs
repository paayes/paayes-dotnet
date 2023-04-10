// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountSettingsCardIssuingOptions : INestedOptions
    {
        /// <summary>
        /// Details on the account's acceptance of the <a
        /// href="https://docs.paayes.com/issuing/connect/tos_acceptance">Paayes Issuing Terms and
        /// Disclosures</a>.
        /// </summary>
        [JsonProperty("tos_acceptance")]
        public AccountSettingsCardIssuingTosAcceptanceOptions TosAcceptance { get; set; }
    }
}
