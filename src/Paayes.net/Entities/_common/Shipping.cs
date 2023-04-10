namespace Paayes
{
    using Newtonsoft.Json;

    public class Shipping : PaayesEntity<Shipping>
    {
        [JsonProperty("address")]
        public Address Address { get; set; }

        [JsonProperty("carrier")]
        public string Carrier { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("tracking_number")]
        public string TrackingNumber { get; set; }
    }
}
