// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountCompanyVerification : PaayesEntity<AccountCompanyVerification>
    {
        [JsonProperty("document")]
        public AccountCompanyVerificationDocument Document { get; set; }
    }
}
