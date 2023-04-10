// File generated from our OpenAPI spec
namespace Paayes.BillingPortal
{
    using Newtonsoft.Json;

    public class ConfigurationUpdateOptions : BaseOptions
    {
        /// <summary>
        /// Whether the configuration is active and can be used to create portal sessions.
        /// </summary>
        [JsonProperty("active")]
        public bool? Active { get; set; }

        /// <summary>
        /// The business information shown to customers in the portal.
        /// </summary>
        [JsonProperty("business_profile")]
        public ConfigurationBusinessProfileOptions BusinessProfile { get; set; }

        /// <summary>
        /// The default URL to redirect customers to when they click on the portal's link to return
        /// to your website. This can be <a
        /// href="https://docs.paayes.com/api/customer_portal/sessions/create#create_portal_session-return_url">overriden</a>
        /// when creating the session.
        /// </summary>
        [JsonProperty("default_return_url")]
        public string DefaultReturnUrl { get; set; }

        /// <summary>
        /// Information about the features available in the portal.
        /// </summary>
        [JsonProperty("features")]
        public ConfigurationFeaturesOptions Features { get; set; }
    }
}
