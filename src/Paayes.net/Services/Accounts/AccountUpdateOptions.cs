// File generated from our OpenAPI spec
namespace Paayes
{
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class AccountUpdateOptions : BaseOptions, IHasMetadata
    {
        /// <summary>
        /// An <a href="https://docs.paayes.com/api#create_account_token">account token</a>, used to
        /// securely provide details to the account.
        /// </summary>
        [JsonProperty("account_token")]
        public string AccountToken { get; set; }

        /// <summary>
        /// Business information about the account.
        /// </summary>
        [JsonProperty("business_profile")]
        public AccountBusinessProfileOptions BusinessProfile { get; set; }

        /// <summary>
        /// The business type.
        /// One of: <c>company</c>, <c>government_entity</c>, <c>individual</c>, or
        /// <c>non_profit</c>.
        /// </summary>
        [JsonProperty("business_type")]
        public string BusinessType { get; set; }

        /// <summary>
        /// Each key of the dictionary represents a capability, and each capability maps to its
        /// settings (e.g. whether it has been requested or not). Each capability will be inactive
        /// until you have provided its specific requirements and Paayes has verified them. An
        /// account may have some of its requested capabilities be active and some be inactive.
        /// </summary>
        [JsonProperty("capabilities")]
        public AccountCapabilitiesOptions Capabilities { get; set; }

        /// <summary>
        /// Information about the company or business. This field is available for any
        /// <c>business_type</c>.
        /// </summary>
        [JsonProperty("company")]
        public AccountCompanyOptions Company { get; set; }

        /// <summary>
        /// Three-letter ISO currency code representing the default currency for the account. This
        /// must be a currency that <a href="https://docs.paayes.com/payouts">Paayes supports in the
        /// account's country</a>.
        /// </summary>
        [JsonProperty("default_currency")]
        public string DefaultCurrency { get; set; }

        /// <summary>
        /// Documents that may be submitted to satisfy various informational requests.
        /// </summary>
        [JsonProperty("documents")]
        public AccountDocumentsOptions Documents { get; set; }

        /// <summary>
        /// The email address of the account holder. This is only to make the account easier to
        /// identify to you. Paayes will never directly email Custom accounts.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("external_account")]
        [JsonConverter(typeof(AnyOfConverter))]
        public AnyOf<string, AccountBankAccountOptions, AccountCardOptions> ExternalAccount { get; set; }

        /// <summary>
        /// Information about the person represented by the account. This field is null unless
        /// <c>business_type</c> is set to <c>individual</c>.
        /// </summary>
        [JsonProperty("individual")]
        public AccountIndividualOptions Individual { get; set; }

        /// <summary>
        /// Set of <a href="https://docs.paayes.com/api/metadata">key-value pairs</a> that you can
        /// attach to an object. This can be useful for storing additional information about the
        /// object in a structured format. Individual keys can be unset by posting an empty value to
        /// them. All keys can be unset by posting an empty value to <c>metadata</c>.
        /// </summary>
        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        /// <summary>
        /// Options for customizing how the account functions within Paayes.
        /// </summary>
        [JsonProperty("settings")]
        public AccountSettingsOptions Settings { get; set; }

        /// <summary>
        /// Details on the account's acceptance of the <a
        /// href="https://docs.paayes.com/connect/updating-accounts#tos-acceptance">Paayes Services
        /// Agreement</a>.
        /// </summary>
        [JsonProperty("tos_acceptance")]
        public AccountTosAcceptanceOptions TosAcceptance { get; set; }
    }
}
