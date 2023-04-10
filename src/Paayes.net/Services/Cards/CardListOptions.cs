namespace Paayes
{
    using Newtonsoft.Json;

    public class CardListOptions : ListOptions
    {
        [JsonProperty("object")]
        internal string Object => "card";
    }
}
