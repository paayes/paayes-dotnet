// File generated from our OpenAPI spec
namespace Paayes.Terminal
{
    using Newtonsoft.Json;

    public class ConnectionToken : PaayesEntity<ConnectionToken>, IHasObject
    {
        /// <summary>
        /// String representing the object's type. Objects of the same type share the same value.
        /// </summary>
        [JsonProperty("object")]
        public string Object { get; set; }

        /// <summary>
        /// The id of the location that this connection token is scoped to. Note that location
        /// scoping only applies to internet-connected readers. For more details, see <a
        /// href="https://docs.paayes.com/terminal/readers/fleet-management#connection-tokens">the
        /// docs on scoping connection tokens</a>.
        /// </summary>
        [JsonProperty("location")]
        public string Location { get; set; }

        /// <summary>
        /// Your application should pass this token to the Paayes Terminal SDK.
        /// </summary>
        [JsonProperty("secret")]
        public string Secret { get; set; }
    }
}
