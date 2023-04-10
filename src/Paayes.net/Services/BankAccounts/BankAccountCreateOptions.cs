namespace Paayes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class BankAccountCreateOptions : BaseOptions, IHasMetadata
    {
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("source")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<string, SourceBankAccount> Source { get; set; }
    }
}
