// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SubscriptionScheduleDefaultSettingsTransferDataOptions : INestedOptions
    {
        /// <summary>
        /// A non-negative decimal between 0 and 100, with at most two decimal places. This
        /// represents the percentage of the subscription invoice subtotal that will be transferred
        /// to the destination account. By default, the entire amount is transferred to the
        /// destination.
        /// </summary>
        [JsonProperty("amount_percent")]
        public decimal? AmountPercent { get; set; }

        /// <summary>
        /// ID of an existing, connected Paayes account.
        /// </summary>
        [JsonProperty("destination")]
        public string Destination { get; set; }
    }
}
