// File generated from our OpenAPI spec
namespace Paayes
{
    using System;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class PaymentIntentNextActionOxxoDisplayDetails : PaayesEntity<PaymentIntentNextActionOxxoDisplayDetails>
    {
        /// <summary>
        /// The timestamp after which the OXXO voucher expires.
        /// </summary>
        [JsonProperty("expires_after")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? ExpiresAfter { get; set; }

        /// <summary>
        /// The URL for the hosted OXXO voucher page, which allows customers to view and print an
        /// OXXO voucher.
        /// </summary>
        [JsonProperty("hosted_voucher_url")]
        public string HostedVoucherUrl { get; set; }

        /// <summary>
        /// OXXO reference number.
        /// </summary>
        [JsonProperty("number")]
        public string Number { get; set; }
    }
}
