// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class InvoiceLineItemAutomaticTaxOptions : INestedOptions
    {
        /// <summary>
        /// Controls whether Paayes will automatically compute tax on this invoice.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
    }
}
