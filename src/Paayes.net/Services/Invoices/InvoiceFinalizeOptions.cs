// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class InvoiceFinalizeOptions : BaseOptions
    {
        /// <summary>
        /// Controls whether Paayes will perform <a
        /// href="https://docs.paayes.com/billing/invoices/overview#auto-advance">automatic
        /// collection</a> of the invoice. When <c>false</c>, the invoice's state will not
        /// automatically advance without an explicit action.
        /// </summary>
        [JsonProperty("auto_advance")]
        public bool? AutoAdvance { get; set; }
    }
}
