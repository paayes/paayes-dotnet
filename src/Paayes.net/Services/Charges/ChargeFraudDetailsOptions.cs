// File generated from our OpenAPI spec
namespace Paayes
{
    using Newtonsoft.Json;

    public class ChargeFraudDetailsOptions : INestedOptions
    {
        /// <summary>
        /// Either <c>safe</c> or <c>fraudulent</c>.
        /// </summary>
        [JsonProperty("user_report")]
        public string UserReport { get; set; }
    }
}
