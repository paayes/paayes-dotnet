namespace Paayes
{
    using Newtonsoft.Json;

    public class SourceTransactionAchCreditTransfer : PaayesEntity<SourceTransactionAchCreditTransfer>
    {
        [JsonProperty("fingerprint")]
        public string Fingerprint { get; set; }

        [JsonProperty("last4")]
        public string Last4 { get; set; }

        [JsonProperty("routing_number")]
        public string RoutingNumber { get; set; }
    }
}
