// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using Newtonsoft.Json;

    public class CardholderIndividualVerificationOptions : INestedOptions
    {
        /// <summary>
        /// An identifying document, either a passport or local ID card.
        /// </summary>
        [JsonProperty("document")]
        public CardholderIndividualVerificationDocumentOptions Document { get; set; }
    }
}
