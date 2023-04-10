// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class QuoteAutomaticTaxOptions : INestedOptions
    {
        /// <summary>
        /// Controls whether Paayes will automatically compute tax on the resulting invoices or
        /// subscriptions as well as the quote itself.
        /// </summary>
        [JsonProperty("enabled")]
        public bool? Enabled { get; set; }
    }
}
