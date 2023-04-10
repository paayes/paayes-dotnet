// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class ApplePayDomainListOptions : ListOptions
    {
        [JsonProperty("domain_name")]
        public string DomainName { get; set; }
    }
}
