// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using System;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class TransactionPurchaseDetailsLodging : PaayesEntity<TransactionPurchaseDetailsLodging>
    {
        /// <summary>
        /// The time of checking into the lodging.
        /// </summary>
        [JsonProperty("check_in_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? CheckInAt { get; set; }

        /// <summary>
        /// The number of nights stayed at the lodging.
        /// </summary>
        [JsonProperty("nights")]
        public long? Nights { get; set; }
    }
}
