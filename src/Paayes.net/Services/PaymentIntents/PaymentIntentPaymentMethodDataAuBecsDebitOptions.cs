// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class PaymentIntentPaymentMethodDataAuBecsDebitOptions : INestedOptions
    {
        /// <summary>
        /// The account number for the bank account.
        /// </summary>
        [JsonProperty("account_number")]
        public string AccountNumber { get; set; }

        /// <summary>
        /// Bank-State-Branch number of the bank account.
        /// </summary>
        [JsonProperty("bsb_number")]
        public string BsbNumber { get; set; }
    }
}
