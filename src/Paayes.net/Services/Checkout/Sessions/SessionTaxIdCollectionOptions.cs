// File generated from our OpenAPI spec
namespace Paayes.Checkout
{
    using Newtonsoft.Json;

    public class SessionTaxIdCollectionOptions : INestedOptions
    {
        /// <summary>
        /// Set to true to enable Tax ID collection.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
    }
}
