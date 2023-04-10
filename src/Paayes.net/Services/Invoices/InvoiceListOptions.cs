// File generated from our OpenAPI spec
namespace Paayes
{
    using System;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class InvoiceListOptions : ListOptionsWithCreated
    {
        [JsonProperty("collection_method")]
        public string CollectionMethod { get; set; }

        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("due_date")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<DateTime?, DateRangeOptions> DueDate { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("subscription")]
        public string Subscription { get; set; }
    }
}
