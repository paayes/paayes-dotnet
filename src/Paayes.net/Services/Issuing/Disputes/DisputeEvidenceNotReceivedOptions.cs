// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using System;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class DisputeEvidenceNotReceivedOptions : INestedOptions
    {
        /// <summary>
        /// (ID of a <a href="https://docs.paayes.com/guides/file-upload">file upload</a>)
        /// Additional documentation supporting the dispute.
        /// </summary>
        [JsonProperty("additional_documentation")]
        public string AdditionalDocumentation { get; set; }

        /// <summary>
        /// Date when the cardholder expected to receive the product.
        /// </summary>
        [JsonProperty("expected_at")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? ExpectedAt { get; set; }

        /// <summary>
        /// Explanation of why the cardholder is disputing this transaction.
        /// </summary>
        [JsonProperty("explanation")]
        public string Explanation { get; set; }

        /// <summary>
        /// Description of the merchandise or service that was purchased.
        /// </summary>
        [JsonProperty("product_description")]
        public string ProductDescription { get; set; }

        /// <summary>
        /// Whether the product was a merchandise or service.
        /// </summary>
        [JsonProperty("product_type")]
        public string ProductType { get; set; }
    }
}
