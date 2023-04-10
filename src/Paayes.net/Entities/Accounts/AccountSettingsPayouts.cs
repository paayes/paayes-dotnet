// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class AccountSettingsPayouts : PaayesEntity<AccountSettingsPayouts>
    {
        /// <summary>
        /// A Boolean indicating if Paayes should try to reclaim negative balances from an attached
        /// bank account. See our <a
        /// href="https://docs.paayes.com/connect/account-balances">Understanding Connect Account
        /// Balances</a> documentation for details. Default value is <c>true</c> for Express
        /// accounts and <c>false</c> for Custom accounts.
        /// </summary>
        [JsonProperty("debit_negative_balances")]
        public bool DebitNegativeBalances { get; set; }

        [JsonProperty("schedule")]
        public AccountSettingsPayoutsSchedule Schedule { get; set; }

        /// <summary>
        /// The text that appears on the bank account statement for payouts. If not set, this
        /// defaults to the platform's bank descriptor as set in the Dashboard.
        /// </summary>
        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }
    }
}
