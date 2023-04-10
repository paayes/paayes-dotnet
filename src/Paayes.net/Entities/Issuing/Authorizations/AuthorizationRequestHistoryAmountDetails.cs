// File generated from our OpenAPI spec
namespace Paayes.Issuing
{
    using Newtonsoft.Json;

    public class AuthorizationRequestHistoryAmountDetails : PaayesEntity<AuthorizationRequestHistoryAmountDetails>
    {
        /// <summary>
        /// The fee charged by the ATM for the cash withdrawal.
        /// </summary>
        [JsonProperty("atm_fee")]
        public long? AtmFee { get; set; }
    }
}
