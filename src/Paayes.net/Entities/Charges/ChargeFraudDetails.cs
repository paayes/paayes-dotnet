// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class ChargeFraudDetails : PaayesEntity<ChargeFraudDetails>
    {
        /// <summary>
        /// Assessments from Paayes. If set, the value is <c>fraudulent</c>.
        /// </summary>
        [JsonProperty("paayes_report")]
        public string PaayesReport { get; set; }

        /// <summary>
        /// Assessments reported by you. If set, possible values of are <c>safe</c> and
        /// <c>fraudulent</c>.
        /// </summary>
        [JsonProperty("user_report")]
        public string UserReport { get; set; }
    }
}
