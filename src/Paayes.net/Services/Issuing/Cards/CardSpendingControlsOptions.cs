// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class CardSpendingControlsOptions : INestedOptions
    {
        /// <summary>
        /// Array of strings containing <a
        /// href="https://docs.paayes.com/api#issuing_authorization_object-merchant_data-category">categories</a>
        /// of authorizations to allow. All other categories will be blocked. Cannot be set with
        /// <c>blocked_categories</c>.
        /// </summary>
        [JsonProperty("allowed_categories")]
        public List<string> AllowedCategories { get; set; }

        /// <summary>
        /// Array of strings containing <a
        /// href="https://docs.paayes.com/api#issuing_authorization_object-merchant_data-category">categories</a>
        /// of authorizations to decline. All other categories will be allowed. Cannot be set with
        /// <c>allowed_categories</c>.
        /// </summary>
        [JsonProperty("blocked_categories")]
        public List<string> BlockedCategories { get; set; }

        /// <summary>
        /// Limit spending with amount-based rules that apply across any cards this card replaced
        /// (i.e., its <c>replacement_for</c> card and <em>that</em> card's <c>replacement_for</c>
        /// card, up the chain).
        /// </summary>
        [JsonProperty("spending_limits")]
        public List<CardSpendingControlsSpendingLimitOptions> SpendingLimits { get; set; }
    }
}
