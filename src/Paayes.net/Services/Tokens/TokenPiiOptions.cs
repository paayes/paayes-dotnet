// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class TokenPiiOptions : INestedOptions
    {
        /// <summary>
        /// The <c>id_number</c> for the PII, in string form.
        /// </summary>
        [JsonProperty("id_number")]
        public string IdNumber { get; set; }
    }
}
