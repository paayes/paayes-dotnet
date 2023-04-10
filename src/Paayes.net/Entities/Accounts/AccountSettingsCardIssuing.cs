// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountSettingsCardIssuing : PaayesEntity<AccountSettingsCardIssuing>
    {
        [JsonProperty("tos_acceptance")]
        public AccountSettingsCardIssuingTosAcceptance TosAcceptance { get; set; }
    }
}
