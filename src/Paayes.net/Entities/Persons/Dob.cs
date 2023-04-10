namespace Paayes
{
    using Newtonsoft.Json;

    public class Dob : PaayesEntity<Dob>
    {
        [JsonProperty("day")]
        public long? Day { get; set; }

        [JsonProperty("month")]
        public long? Month { get; set; }

        [JsonProperty("year")]
        public long? Year { get; set; }
    }
}
