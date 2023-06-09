// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class SetupIntentPaymentMethodOptionsAcssDebitMandateOptions : PaayesEntity<SetupIntentPaymentMethodOptionsAcssDebitMandateOptions>
    {
        /// <summary>
        /// A URL for custom mandate text.
        /// </summary>
        [JsonProperty("custom_mandate_url")]
        public string CustomMandateUrl { get; set; }

        /// <summary>
        /// Description of the interval. Only required if 'payment_schedule' parmeter is 'interval'
        /// or 'combined'.
        /// </summary>
        [JsonProperty("interval_description")]
        public string IntervalDescription { get; set; }

        /// <summary>
        /// Payment schedule for the mandate.
        /// One of: <c>combined</c>, <c>interval</c>, or <c>sporadic</c>.
        /// </summary>
        [JsonProperty("payment_schedule")]
        public string PaymentSchedule { get; set; }

        /// <summary>
        /// Transaction type of the mandate.
        /// One of: <c>business</c>, or <c>personal</c>.
        /// </summary>
        [JsonProperty("transaction_type")]
        public string TransactionType { get; set; }
    }
}
