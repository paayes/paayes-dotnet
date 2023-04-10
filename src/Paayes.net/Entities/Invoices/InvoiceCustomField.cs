// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class InvoiceCustomField : PaayesEntity<InvoiceCustomField>
    {
        /// <summary>
        /// The name of the custom field.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// The value of the custom field.
        /// </summary>
        [JsonProperty("value")]
        public string Value { get; set; }
    }
}
