// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class CustomerListOptions : ListOptionsWithCreated
    {
        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
