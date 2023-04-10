namespace Paayes.Radar
{
    using Newtonsoft.Json;

    public class Rule : PaayesEntity<Rule>, IHasId
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("action")]
        public string Action { get; set; }

        [JsonProperty("deleted", NullValueHandling = NullValueHandling.Ignore)]
        public bool? Deleted { get; set; }

        [JsonProperty("predicate")]
        public string Predicate { get; set; }
    }
}
