// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class TokenCreateOptions : BaseOptions
    {
        /// <summary>
        /// Information for the account this token will represent.
        /// </summary>
        [JsonProperty("account")]
        public TokenAccountOptions Account { get; set; }

        [JsonProperty("bank_account")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<string, TokenBankAccountOptions> BankAccount { get; set; }

        [JsonProperty("card")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<string, TokenCardOptions> Card { get; set; }

        /// <summary>
        /// The customer (owned by the application's account) for which to create a token. This can
        /// be used only with an <a href="https://docs.paayes.com/connect/standard-accounts">OAuth
        /// access token</a> or <a
        /// href="https://docs.paayes.com/connect/authentication">Paayes-Account header</a>. For
        /// more details, see <a
        /// href="https://docs.paayes.com/connect/cloning-saved-payment-methods">Cloning Saved
        /// Payment Methods</a>.
        /// </summary>
        [JsonProperty("customer")]
        public string Customer { get; set; }

        /// <summary>
        /// The updated CVC value this token will represent.
        /// </summary>
        [JsonProperty("cvc_update")]
        public TokenCvcUpdateOptions CvcUpdate { get; set; }

        /// <summary>
        /// Information for the person this token will represent.
        /// </summary>
        [JsonProperty("person")]
        public TokenPersonOptions Person { get; set; }

        /// <summary>
        /// The PII this token will represent.
        /// </summary>
        [JsonProperty("pii")]
        public TokenPiiOptions Pii { get; set; }
    }
}
