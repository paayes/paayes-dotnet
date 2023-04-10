// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class TokenCvcUpdateOptions : INestedOptions
    {
        /// <summary>
        /// The CVC value, in string form.
        /// </summary>
        [JsonProperty("cvc")]
        public string Cvc { get; set; }
    }
}
