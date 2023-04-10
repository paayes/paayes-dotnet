namespace Paayes
{
    using Newtonsoft.Json;

    public class OAuthDeauthorize : PaayesEntity<OAuthDeauthorize>
    {
        /// <summary>
        /// The unique id of the account you have revoked access to, as a string. This is the same
        /// as the <see cref="OAuthDeauthorizeOptions.PaayesUserId"/> you passed in. If this is
        /// returned, the revocation was successful.
        /// </summary>
        [JsonProperty("paayes_user_id")]
        public string PaayesUserId { get; set; }
    }
}
