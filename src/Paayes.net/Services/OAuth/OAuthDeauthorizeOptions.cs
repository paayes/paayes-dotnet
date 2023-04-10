namespace Paayes
{
    using Newtonsoft.Json;

    public class OAuthDeauthorizeOptions : BaseOptions
    {
        /// <summary>
        /// The <c>client_id</c> of the application that you'd like to disconnect the account from.
        /// The account must be connected to this application.
        /// </summary>
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        /// <summary>The account you'd like to disconnect from.</summary>
        [JsonProperty("paayes_user_id")]
        public string PaayesUserId { get; set; }
    }
}
