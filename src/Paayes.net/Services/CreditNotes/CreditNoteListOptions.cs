// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class CreditNoteListOptions : ListOptions
    {
        [JsonProperty("customer")]
        public string Customer { get; set; }

        [JsonProperty("invoice")]
        public string Invoice { get; set; }
    }
}
