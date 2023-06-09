// File generated from our OpenAPI spec
namespace Paayes
{
    using System;
    using Newtonsoft.Json;
    using Paayes.Infrastructure;

    public class AccountTosAcceptance : PaayesEntity<AccountTosAcceptance>
    {
        /// <summary>
        /// The Unix timestamp marking when the account representative accepted their service
        /// agreement.
        /// </summary>
        [JsonProperty("date")]
        [JsonConverter(typeof(UnixDateTimeConverter))]
        public DateTime? Date { get; set; }

        /// <summary>
        /// The IP address from which the account representative accepted their service agreement.
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// The user's service agreement type.
        /// </summary>
        [JsonProperty("service_agreement")]
        public string ServiceAgreement { get; set; }

        /// <summary>
        /// The user agent of the browser from which the account representative accepted their
        /// service agreement.
        /// </summary>
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }
    }
}
