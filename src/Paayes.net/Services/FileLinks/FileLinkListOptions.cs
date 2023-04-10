// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class FileLinkListOptions : ListOptionsWithCreated
    {
        [JsonProperty("expired")]
        public bool? Expired { get; set; }

        [JsonProperty("file")]
        public string File { get; set; }
    }
}
