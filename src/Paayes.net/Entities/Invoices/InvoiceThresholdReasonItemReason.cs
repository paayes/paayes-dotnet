// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class InvoiceThresholdReasonItemReason : PaayesEntity<InvoiceThresholdReasonItemReason>
    {
        /// <summary>
        /// The IDs of the line items that triggered the threshold invoice.
        /// </summary>
        [JsonProperty("line_item_ids")]
        public List<string> LineItemIds { get; set; }

        /// <summary>
        /// The quantity threshold boundary that applied to the given line item.
        /// </summary>
        [JsonProperty("usage_gte")]
        public long UsageGte { get; set; }
    }
}
