namespace Paayes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class BalanceAmount : PaayesEntity<BalanceAmount>
    {
        [JsonProperty("amount")]
        public long Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("source_types")]
        public Dictionary<string, long> SourceTypes { get; set; }
    }
}
