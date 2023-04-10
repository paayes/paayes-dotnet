// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using Newtonsoft.Json;

    public class CardholderCompany : PaayesEntity<CardholderCompany>
    {
        /// <summary>
        /// Whether the company's business ID number was provided.
        /// </summary>
        [JsonProperty("tax_id_provided")]
        public bool TaxIdProvided { get; set; }
    }
}
