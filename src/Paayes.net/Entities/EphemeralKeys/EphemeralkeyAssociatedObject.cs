// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class EphemeralKeyAssociatedObject : PaayesEntity<EphemeralKeyAssociatedObject>, IHasId
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }
    }
}
