// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class BalanceInstantAvailable : PaayesEntity<BalanceInstantAvailable>
    {
        /// <summary>
        /// Balance amount.
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Three-letter <a href="https://www.iso.org/iso-4217-currency-codes.html">ISO currency
        /// code</a>, in lowercase. Must be a <a href="https://docs.paayes.com/currencies">supported
        /// currency</a>.
        /// </summary>
        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("source_types")]
        public BalanceInstantAvailableSourceTypes SourceTypes { get; set; }
    }
}
