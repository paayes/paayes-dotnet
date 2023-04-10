// File generated from our OpenAPI spec
namespace Paayes.Checkout
{
    using Newtonsoft.Json;

    public class SessionTaxIdCollection : PaayesEntity<SessionTaxIdCollection>
    {
        /// <summary>
        /// Indicates whether tax ID collection is enabled for the session.
        /// </summary>
        [JsonProperty("enabled")]
        public bool Enabled { get; set; }
    }
}
