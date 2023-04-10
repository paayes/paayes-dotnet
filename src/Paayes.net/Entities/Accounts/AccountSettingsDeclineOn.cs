namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountSettingsDeclineOn : PaayesEntity<AccountSettingsDeclineOn>
    {
        [JsonProperty("avs_failure")]
        public bool AvsFailure { get; set; }

        [JsonProperty("cvc_failure")]
        public bool CvcFailure { get; set; }
    }
}
