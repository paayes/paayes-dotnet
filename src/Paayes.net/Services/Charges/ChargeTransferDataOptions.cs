// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class ChargeTransferDataOptions : INestedOptions
    {
        /// <summary>
        /// The amount transferred to the destination account, if specified. By default, the entire
        /// charge amount is transferred to the destination account.
        /// </summary>
        [JsonProperty("amount")]
        public long? Amount { get; set; }

        /// <summary>
        /// ID of an existing, connected Paayes account.
        /// </summary>
        [JsonProperty("destination")]
        public string Destination { get; set; }
    }
}
