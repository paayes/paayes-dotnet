// File generated from our OpenAPI spec
namespace Paayes.Checkout
{
    using Newtonsoft.Json;

    public class SessionAutomaticTaxOptions : INestedOptions
    {
        /// <summary>
        /// Set to true to enable automatic taxes.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
    }
}
