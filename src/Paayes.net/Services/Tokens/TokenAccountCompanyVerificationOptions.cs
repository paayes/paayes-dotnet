// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class TokenAccountCompanyVerificationOptions : INestedOptions
    {
        /// <summary>
        /// A document verifying the business.
        /// </summary>
        [JsonProperty("document")]
        public TokenAccountCompanyVerificationDocumentOptions Document { get; set; }
    }
}
