// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class FileListOptions : ListOptionsWithCreated
    {
        [JsonProperty("purpose")]
        public string Purpose { get; set; }
    }
}
