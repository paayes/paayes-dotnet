// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountBusinessProfileOptions : INestedOptions
    {
        /// <summary>
        /// <a href="https://docs.paayes.com/connect/setting-mcc">The merchant category code for the
        /// account</a>. MCCs are used to classify businesses based on the goods or services they
        /// provide.
        /// </summary>
        [JsonProperty("mcc")]
        public string Mcc { get; set; }

        /// <summary>
        /// The customer-facing business name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        /// Internal-only description of the product sold by, or service provided by, the business.
        /// Used by Paayes for risk and underwriting purposes.
        /// </summary>
        [JsonProperty("product_description")]
        public string ProductDescription { get; set; }

        /// <summary>
        /// A publicly available mailing address for sending support issues to.
        /// </summary>
        [JsonProperty("support_address")]
        public AddressOptions SupportAddress { get; set; }

        /// <summary>
        /// A publicly available email address for sending support issues to.
        /// </summary>
        [JsonProperty("support_email")]
        public string SupportEmail { get; set; }

        /// <summary>
        /// A publicly available phone number to call with support issues.
        /// </summary>
        [JsonProperty("support_phone")]
        public string SupportPhone { get; set; }

        /// <summary>
        /// A publicly available website for handling support issues.
        /// </summary>
        [JsonProperty("support_url")]
        public string SupportUrl { get; set; }

        /// <summary>
        /// The business's publicly available website.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; }
    }
}
