namespace Paayes
{
    using Newtonsoft.Json;

    public class Application : PaayesEntity<Application>, IHasId, IHasObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("object")]
        public string Object { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
