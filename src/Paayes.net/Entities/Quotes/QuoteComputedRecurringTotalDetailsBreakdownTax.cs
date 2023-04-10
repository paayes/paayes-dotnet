// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class QuoteComputedRecurringTotalDetailsBreakdownTax : PaayesEntity<QuoteComputedRecurringTotalDetailsBreakdownTax>
    {
        /// <summary>
        /// Amount of tax applied for this rate.
        /// </summary>
        [JsonProperty("amount")]
        public long Amount { get; set; }

        /// <summary>
        /// Tax rates can be applied to <a
        /// href="https://docs.paayes.com/billing/invoices/tax-rates">invoices</a>, <a
        /// href="https://docs.paayes.com/billing/subscriptions/taxes">subscriptions</a> and <a
        /// href="https://docs.paayes.com/payments/checkout/set-up-a-subscription#tax-rates">Checkout
        /// Sessions</a> to collect tax.
        ///
        /// Related guide: <a href="https://docs.paayes.com/billing/taxes/tax-rates">Tax Rates</a>.
        /// </summary>
        [JsonProperty("rate")]
        public TaxRate Rate { get; set; }
    }
}
