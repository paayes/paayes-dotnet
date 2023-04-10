// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using Newtonsoft.Json;

    public class CardholderBilling : PaayesEntity<CardholderBilling>
    {
        [JsonProperty("address")]
        public Address Address { get; set; }
    }
}
