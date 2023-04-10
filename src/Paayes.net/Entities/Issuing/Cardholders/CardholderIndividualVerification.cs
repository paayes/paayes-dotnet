// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using Newtonsoft.Json;

    public class CardholderIndividualVerification : PaayesEntity<CardholderIndividualVerification>
    {
        /// <summary>
        /// An identifying document, either a passport or local ID card.
        /// </summary>
        [JsonProperty("document")]
        public CardholderIndividualVerificationDocument Document { get; set; }
    }
}
