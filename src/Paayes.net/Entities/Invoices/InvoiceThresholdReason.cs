// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class InvoiceThresholdReason : PaayesEntity<InvoiceThresholdReason>
    {
        /// <summary>
        /// The total invoice amount threshold boundary if it triggered the threshold invoice.
        /// </summary>
        [JsonProperty("amount_gte")]
        public long? AmountGte { get; set; }

        /// <summary>
        /// Indicates which line items triggered a threshold invoice.
        /// </summary>
        [JsonProperty("item_reasons")]
        public List<InvoiceThresholdReasonItemReason> ItemReasons { get; set; }
    }
}
