// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class BalanceInstantAvailableSourceTypes : PaayesEntity<BalanceInstantAvailableSourceTypes>
    {
        /// <summary>
        /// Amount for bank account.
        /// </summary>
        [JsonProperty("bank_account")]
        public long BankAccount { get; set; }

        /// <summary>
        /// Amount for card.
        /// </summary>
        [JsonProperty("card")]
        public long Card { get; set; }

        /// <summary>
        /// Amount for FPX.
        /// </summary>
        [JsonProperty("fpx")]
        public long Fpx { get; set; }
    }
}
