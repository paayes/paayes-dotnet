namespace Paayes
{
    using Newtonsoft.Json;

    public class AddressJapan : Address
    {
        [JsonProperty("town")]
        public string Town { get; set; }
    }
}
