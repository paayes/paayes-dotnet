// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class TransferListOptions : ListOptionsWithCreated
    {
        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("transfer_group")]
        public string TransferGroup { get; set; }
    }
}
